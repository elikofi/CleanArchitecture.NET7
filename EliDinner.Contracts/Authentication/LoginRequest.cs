using System;
namespace EliDinner.Contracts.Authentication
{
    public record LoginRequest(
    string Email,
    string Password
    );
}

