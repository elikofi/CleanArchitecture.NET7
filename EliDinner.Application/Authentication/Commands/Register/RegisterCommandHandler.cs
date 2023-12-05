using System;
using EliDinner.Application.Common.Interfaces.Authentication;
using EliDinner.Application.Common.Interfaces.Persistence;
using EliDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using EliDinner.Domain.Entities;
using EliDinner.Application.Authentication.Common;

namespace EliDinner.Application.Authentication.Commands.Register
{
    //the command handler implements the IRequest interface from the mediatR package.
    //It then receives the command that it handles <Register command> and then the response that it returns ,ErrorOr
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUserRepository userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // 1. Validate the user doesn't exist
            if (userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }


            // 2. create user (generate unique ID) & persist the user to the DB
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            userRepository.Add(user);

            // 3.create JWT token
            var token = jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult(user, token);
        }
    }
}

