using FutureComputer.Application.Configs;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FutureComputer.Application.Users.LoginUser;

public class UserLoginHandler : IRequestHandler<UserLoginCommand, string>
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Role> _roleRepository;
    private readonly IConfiguration _configuration;
    public UserLoginHandler(IRepository<User> userRepository, IRepository<Role> roleRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _configuration = configuration;
    }

    public async Task<string> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        Hash(request.Password, out byte[] hash, out byte[] salt);

        var user = await GetSpecificUser(request.Email, request.Password, hash, salt);
        if(user== null) 
        {
            return "Login failed.";
        }

        var token = await CreateToken(user);

        return token;
    }

    private async Task<string> CreateToken(User user)
    {
        var roleSpecification = new GetUserRoleSpecification(user.RoleId);

        var role = await _roleRepository.FirstOrDefaultAsync(roleSpecification);
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, role.RoleName)
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

    private async Task<User> GetSpecificUser(string email, string password, byte[] hash, byte[] salt)
    {
        byte[] computedHash = null;

        var getAllUserSpecification = new GetAllUserSpecification();

        var allUsers = await _userRepository.ListAsync(getAllUserSpecification);
        foreach(var user in allUsers)
        {
            using (var hmac = new HMACSHA512(user.Salt))
            {
                computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                if(user.Hash.SequenceEqual(computedHash))
                {
                    return user;
                }
            }
        }

        return null;
    }

    public void Hash(string password, out byte[] hash, out byte[] salt)
    {
        using (var hmac = new HMACSHA512())
        {
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
