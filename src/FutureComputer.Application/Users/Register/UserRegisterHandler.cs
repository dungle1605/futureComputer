﻿using FutureComputer.Application.Configs;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Enum;
using FutureComputer.Domain.Interfaces;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace FutureComputer.Application.Users.Register
{
    public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, string>
    {
        private readonly IRepository<User> _repository;
        private readonly MappingProfile<UserRegisterCommand, User> _mappingProfile;
        public UserRegisterHandler(IRepository<User> repository, MappingProfile<UserRegisterCommand, User> mappingProfile)
        {
            _repository = repository;
            _mappingProfile = mappingProfile;
        }

        public async Task<string> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var isUserExisted = await IsUserExisted(request.UserName);

            if (isUserExisted)
            {
                return "User is existed in system, please check!";
            }

            var isExistedEmail = await IsExistedEmail(request.Email);

            if (isExistedEmail)
            {
                return "Email is existed in system, please check!";
            }

            Hash(request.Password, out byte[] hash, out byte[] salt);

            var user = _mappingProfile.MapperHandler(request);
            user.Created = DateTime.Now;
            user.Hash = hash;
            user.Salt = salt;
            user.Id = Guid.NewGuid();
            user.RoleId = (int)BaseRole.Admin;

            await _repository.AddAsync(user, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return "Add User Successfully";
        }

        private static void Hash(string password, out byte[] hash, out byte[] salt)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private async Task<bool> IsUserExisted(string? username)
        {
            var getUserByUsernameSpec = new GetUserByUsernameSpecifification(username);
            return await _repository.AnyAsync(getUserByUsernameSpec);
        }

        private async Task<bool> IsExistedEmail(string? email)
        {
            var getUserByEmailSpec = new GetUserByEmailSpecification(email);

            return await _repository.AnyAsync(getUserByEmailSpec);
        }
    }
}
