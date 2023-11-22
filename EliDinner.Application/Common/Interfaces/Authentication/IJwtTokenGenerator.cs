using System;
using EliDinner.Domain.Entities;

namespace EliDinner.Application.Common.Interfaces.Authentication
{
	public interface IJwtTokenGenerator
	{
		string GenerateToken(User user);
	}
}

