using ey2020UserManager.Persistence.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ey2020UserManager.Persistence
{
	public class UserRoleManagerDbContext : DbContext
	{
		public UserRoleManagerDbContext(DbContextOptions options)
			:base(options)
		{
		}

		DbSet<User> Users { get; set; }
		DbSet<Role> Roles { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<User>().HasIndex(e => e.Id).IsUnique();

			builder.Entity<Role>().HasIndex(e => e.Id).IsUnique();
		}
	}
}
