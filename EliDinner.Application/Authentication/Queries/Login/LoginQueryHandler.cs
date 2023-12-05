using System;
using EliDinner.Application.Authentication.Commands.Register;
using EliDinner.Application.Common.Interfaces.Authentication;
using EliDinner.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using EliDinner.Domain.Common.Errors;
using EliDinner.Domain.Entities;
using EliDinner.Application.Authentication.Common;

namespace EliDinner.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUserRepository userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // 1. Validate user exists.
            if (userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }



            // 2. Validate the password is correct.
            if (user.Password != query.Password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };
            }


            // 3. Create JWT token

            var token = jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}

