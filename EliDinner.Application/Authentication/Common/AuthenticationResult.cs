using System;
using EliDinner.Domain.Entities;

namespace EliDinner.Application.Authentication.Common
{
	public record AuthenticationResult(User User, string Token);
}

