using EliDinner.Application.Common.Errors;
using ErrorOr;

namespace EliDinner.Application.Services.Authentication
{
    public interface IAuthenticationService
	{
        ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

        ErrorOr<AuthenticationResult> Login(string email, string password);

        
    }
}

