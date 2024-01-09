using System;
using EliDinner.Domain.Menu;

namespace EliDinner.Application.Common.Interfaces.Persistence
{
	public interface IMenuRepository
	{
		void Add(Menu menu);
	}
}

