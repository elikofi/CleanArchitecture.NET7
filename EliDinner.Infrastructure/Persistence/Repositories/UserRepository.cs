using System;
using EliDinner.Application.Common.Interfaces.Persistence;
using EliDinner.Domain.Entities;

namespace EliDinner.Infrastructure.Persistence.Repositories
{
	public class UserRepository : IUserRepository
	{
        private static readonly List<User> users = new();

        public void Add(User user)
        {
            users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return users.SingleOrDefault(x => x.Email == email);
        }
    }
}

