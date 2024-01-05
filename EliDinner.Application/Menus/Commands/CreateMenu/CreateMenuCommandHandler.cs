using System;
using EliDinner.Domain.Host.ValueObjects;
using EliDinner.Domain.Menu;
using EliDinner.Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace EliDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        public Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            //Create Menu
            //var menu = Menu.Create(
            //    hostId: HostId.Create(request.HostId),
            //    request.Name,
            //    request.Description,
            //    request.Sections.ConvertAll(section => MenuSection.Create(
            //        section.Name,
            //        section.Description,
            //        section.Items.ConvertAll(item => MenuItem.Create(
            //            item.Name,
            //            item.Description)))));
            //Persist Menu
            //Return Menu
            return default!;
        }
    }
}

