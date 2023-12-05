using System;
using EliDinner.Application.Authentication.Commands.Register;
using EliDinner.Application.Authentication.Common;
using EliDinner.Application.Authentication.Queries.Login;
using EliDinner.Contracts.Authentication;
using Mapster;

namespace EliDinner.Api.Common.Mapping
{
    //Over here are all the various configurations that has to do with authentication
    //Implements the IRegister interface which has a single register method
    //they only config we need here is between the auth results and the auth response
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();


            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token) //the token in the destination(auth response) comes from the token in the src(auth result)
                 //if the properties have the same name, then no need defining them so we can get rid of the line just above this.
                .Map(dest => dest, src => src.User);        //the rest of the properties are coming from the user object. src (auth result.User)
        }
    }
}

