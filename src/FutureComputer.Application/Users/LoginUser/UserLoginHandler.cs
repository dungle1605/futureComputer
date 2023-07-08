using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Enum;
using FutureComputer.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FutureComputer.Application.Users.LoginUser;

public class UserLoginHandler : IRequestHandler<UserLoginCommand, string>
{
    private readonly IRepository<User> _userRepository;
    private readonly IConfiguration _configuration;
    public UserLoginHandler(IRepository<User> userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<string> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        Hash(request.Password, out byte[] hash, out byte[] salt);

        var user = await GetSpecificUser(request.Email, request.Password, hash, salt);
        if (user == null)
        {
            return "Login failed.";
        }

        var token = CreateToken(user);

        return token;
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, ((BaseRole)user.RoleId).GetEnumDescription()),
            new Claim(ClaimTypes.Sid, user.Id.ToString())
        };

        var tokenSection = _configuration.GetSection("AppSettings:Token").Value;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSection));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    private async Task<User?> GetSpecificUser(string email, string password, byte[] hash, byte[] salt)
    {
        var getUserSpecification = new GetUserByEmailSpecification(email);
        var user = await _userRepository.FirstOrDefaultAsync(getUserSpecification);
        if (user != null)
        {
            using var hmac = new HMACSHA512(user.Salt);
            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            if (user.Hash.SequenceEqual(computedHash))
            {
                return user;
            }
            return null;
        }
        return null;
    }

    private static void Hash(string password, out byte[] hash, out byte[] salt)
    {
        using var hmac = new HMACSHA512();
        salt = hmac.Key;
        hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}
