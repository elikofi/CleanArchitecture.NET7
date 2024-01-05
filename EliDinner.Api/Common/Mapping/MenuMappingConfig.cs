using System;
using EliDinner.Application.Authentication.Commands.Register;
using EliDinner.Application.Authentication.Common;
using EliDinner.Application.Authentication.Queries.Login;
using EliDinner.Application.Menus.Commands.CreateMenu;
using EliDinner.Contracts.Authentication;
using EliDinner.Contracts.Menus;
using Mapster;

namespace EliDinner.Api.Common.Mapping
{
	public class MenuMappingConfig : IRegister
	{
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);    
        }
    }
}

