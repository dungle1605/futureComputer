using FutureComputer.Application.Configs;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Application.Users.Register
{
    public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, string>
    {
        private readonly IRepository<User> _repository;
        private readonly IRepository<Role> _roleRepository;
        private readonly MappingProfile<UserRegisterCommand, User> _mappingProfile;
        public UserRegisterHandler(IRepository<User> repository,  MappingProfile<UserRegisterCommand, User> mappingProfile, IRepository<Role> roleRepository)
        {
            _repository = repository;
            _mappingProfile = mappingProfile;
            _roleRepository = roleRepository;
        }

        public async Task<string> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            Hash(request.Password, out byte[] hash, out byte[] salt);

            var adminRoleSpecification = new UserAdminRegisterSpecification();

            var adminRole = await _roleRepository.FirstOrDefaultAsync(adminRoleSpecification);

            var user = _mappingProfile.MapperHandler(request);
            user.Created = DateTime.Now;
            user.Hash= hash;
            user.Salt= salt;
            user.Id = Guid.NewGuid();
            user.RoleId = adminRole.Id;

            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync();

            return "Add User Successfully";
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
}
