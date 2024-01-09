using System;
using EliDinner.Application.Common.Interfaces.Persistence;
using EliDinner.Domain.Menu;

namespace EliDinner.Infrastructure.Persistence.Repositories
{
	public class MenuRepository : IMenuRepository
	{
		private readonly EliDinnerDbContext _dbContext;

        public MenuRepository(EliDinnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Menu menu)
		{
			_dbContext.Add(menu);

			_dbContext.SaveChanges();
		}
	}
}

