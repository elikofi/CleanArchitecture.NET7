using System;
using EliDinner.Domain.Entities;

namespace EliDinner.Application.Common.Interfaces.Persistence
{
	public interface IUserRepository
	{
		User? GetUserByEmail(string email);

		void Add(User user);
	}
}

