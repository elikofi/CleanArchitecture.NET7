using System;
using EliDinner.Domain.Menu;
using Microsoft.EntityFrameworkCore;

namespace EliDinner.Infrastructure.Persistence
{
	public class EliDinnerDbContext : DbContext
	{
		public EliDinnerDbContext(DbContextOptions<EliDinnerDbContext> options) : base(options)
		{

		}


		public DbSet<Menu> Menus { get; set; } = null!;
	}
}

