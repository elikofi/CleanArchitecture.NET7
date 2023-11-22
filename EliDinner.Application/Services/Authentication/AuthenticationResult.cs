using System;
using EliDinner.Domain.Entities;

namespace EliDinner.Application.Services.Authentication
{
    public record AuthenticationResult(
    User User,
    string Token
    );
}

