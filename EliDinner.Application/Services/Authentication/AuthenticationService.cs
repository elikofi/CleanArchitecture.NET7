using EliDinner.Application.Common.Errors;
using EliDinner.Application.Common.Interfaces.Authentication;
using EliDinner.Application.Common.Interfaces.Persistence;
using EliDinner.Domain.Common.Errors;
using EliDinner.Domain.Entities;
using ErrorOr;
using FluentResults;

namespace EliDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
	{
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUserRepository userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            // 1. Validate the user doesn't exist
            if (userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }


            // 2. create user (generate unique ID) & persist the user to the DB
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            userRepository.Add(user);

            // 3.create JWT token
            var token = jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult(user, token);
        }


        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            // 1. Validate user exists.
            if (userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }



            // 2. Validate the password is correct.
            if (user.Password != password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };
            }


            // 3. Create JWT token

            var token = jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }

        
    }
}

