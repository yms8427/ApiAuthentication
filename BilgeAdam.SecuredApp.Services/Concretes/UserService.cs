using BilgeAdam.SecuredApp.Data;
using BilgeAdam.SecuredApp.Data.Entities;
using BilgeAdam.SecuredApp.Services.Abstractions;
using BilgeAdam.SecuredApp.Services.Contracts;
using BilgeAdam.SecuredApp.Services.Extensions;
using System;
using System.Linq;

namespace BilgeAdam.SecuredApp.Services.Concretes
{
    internal class UserService : IUserService
    {
        private readonly NorthwindContext context;

        public UserService(NorthwindContext context)
        {
            this.context = context;
        }
        public UserInfoDto Login(string userName, string password)
        {
            var hash = password.ComputeHash();
            var user = context.Users.FirstOrDefault(f => f.UserName == userName && f.Password == hash);
            if (user != null)
            {
                return new UserInfoDto
                {
                    Id = user.UserId,
                    UserName = user.UserName,
                    FullName = $"{user.FirstName} {user.LastName}"
                };
            }
            return null;
        }

        public bool Register(RegisterDto data)
        {
            var @new = new User
            {
                UserName = data.UserName.Trim().ToLower(),
                FirstName = data.FirstName,
                LastName = data.LastName,
                BirthDate = data.BirthDate,
                IsActive = true,
                Password = data.Password.ComputeHash()
            };
            context.Users.Add(@new);
            return context.SaveChanges() > 0;
        }
    }
}