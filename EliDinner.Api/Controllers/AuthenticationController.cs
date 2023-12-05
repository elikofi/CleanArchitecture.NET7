using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EliDinner.Application.Authentication.Commands.Register;
using EliDinner.Application.Authentication.Common;
using EliDinner.Application.Authentication.Queries.Login;
using EliDinner.Contracts.Authentication;
using EliDinner.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EliDinner.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
                

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));

        }   


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            var authResults = await _mediator.Send(query);

             

            return authResults.Match(
                authResults => Ok(_mapper.Map<AuthenticationResponse>(authResults)),
                errors => Problem(errors));
        }


    }

}

