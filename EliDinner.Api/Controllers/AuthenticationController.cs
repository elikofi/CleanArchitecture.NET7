using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EliDinner.Application.Common.Errors;
using EliDinner.Application.Services.Authentication;
using EliDinner.Contracts.Authentication;
using EliDinner.Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EliDinner.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService; 
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));

        }   


        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResults = _authenticationService.Login(
                request.Email,
                request.Password);

            //if (Errors.Authentication.InvalidCredentials == authResults.IsError && authResults.FirstError)
            //{
            //    return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResults.FirstError.Description);
            //}

            return authResults.Match(
                authResults => Ok(MapAuthResult(authResults)),
                errors => Problem(errors));
        }


        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                                authResult.User.Id,
                                authResult.User.FirstName,
                                authResult.User.LastName,
                                authResult.User.Email,
                                authResult.Token);
        }
    }

}

