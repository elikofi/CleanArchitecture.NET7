using System;
namespace EliDinner.Contracts.Authentication
{
    public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
    );
}

