using System;
using Microsoft.EntityFrameworkCore;

namespace Menu.Context
{
	public class MenuContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}

