using System;
using EliDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace EliDinner.Application.Authentication.Queries.Login
{
    //this returns the authentication result, and the authentication results also returns the User object
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}

