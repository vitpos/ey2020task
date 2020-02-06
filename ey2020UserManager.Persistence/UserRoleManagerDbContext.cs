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
		public const int SqlShortStringLength = 16;

		public UserRoleManagerDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<User> Users { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<UserAuthorization> UserAuthorizations { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<User>().HasIndex(e => e.Id).IsUnique();
			builder.Entity<User>().Property(e => e.FirstName).HasMaxLength(SqlCommonStringLength);
			builder.Entity<User>().Property(e => e.LastName).HasMaxLength(SqlCommonStringLength);
			builder.Entity<User>().Property(e => e.PhoneNumber).HasMaxLength(SqlShortStringLength);
			builder.Entity<User>().Property(e => e.Email).HasMaxLength(SqlCommonStringLength);

			builder.Entity<Role>().HasIndex(e => e.Id).IsUnique();
			builder.Entity<Role>().Property(e => e.RoleName).HasMaxLength(SqlCommonStringLength);

			builder.Entity<UserAuthorization>().HasIndex(e => e.Id).IsUnique();
			builder.Entity<UserAuthorization>().HasKey(e => e.Id);
			
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
