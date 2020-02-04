using ey2020UserManager.Persistence.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ey2020UserManager.Persistence
{
	public class UserRoleManagerDbContext : DbContext
	{
		public const int SqlCommonStringLength = 256;

		public UserRoleManagerDbContext(DbContextOptions options)
			: base(options)
		{
		}

		DbSet<User> Users { get; set; }

		DbSet<Role> Roles { get; set; }

		DbSet<UserAuthorization> UserAuthorizations { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<User>().HasIndex(e => e.Id).IsUnique();
			builder.Entity<User>().Property(e => e.FirstName).HasMaxLength(SqlCommonStringLength);
			builder.Entity<User>().Property(e => e.LastName).HasMaxLength(SqlCommonStringLength);
			builder.Entity<User>().Property(e => e.PhoneNumber).HasMaxLength(SqlCommonStringLength);
			builder.Entity<User>().Property(e => e.Email).HasMaxLength(SqlCommonStringLength);

			builder.Entity<Role>().HasIndex(e => e.Id).IsUnique();
			builder.Entity<Role>().Property(e => e.RoleName).HasMaxLength(SqlCommonStringLength);

			builder.Entity<UserAuthorization>().HasKey(x => x.Id);
			builder.Entity<UserAuthorization>()
					.HasOne(pt => pt.User)
					.WithMany(p => p.LinkedRoles)
					.HasForeignKey(pt => pt.UserId);

			builder.Entity<UserAuthorization>()
					.HasOne(pt => pt.Role)
					.WithMany(t => t.LinkedUsers)
					.HasForeignKey(pt => pt.RoleId);
		}
	}
}
