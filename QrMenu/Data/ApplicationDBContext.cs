using System;
using Microsoft.EntityFrameworkCore;
using QrMenu.Models;

namespace QrMenu.Data
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
		{

		}
		public DbSet<Company>? Companies { get; set; }
		public DbSet<State>?  States { get; set; }
        public DbSet<Food>? Foods { get; set; }
		public DbSet<Category> Categories { get; set; }
    }
}

