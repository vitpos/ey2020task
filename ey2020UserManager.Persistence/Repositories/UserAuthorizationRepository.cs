using ey2020UserManager.Persistence.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ey2020UserManager.Persistence.Repositories
{
	public class UserAuthorizationRepository : IUserAuthorizationRepository
	{
		private readonly UserRoleManagerDbContext _dbContext;

		public UserAuthorizationRepository(UserRoleManagerDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public bool IsAllRolesExists(IEnumerable<int> roleIds)
		{
			var roles = _dbContext.Set<Role>().AsNoTracking().Where(x => x.IsEnabled).Select(x => x.Id);
			return !roleIds.Except(roles).Any();
		}

		public async Task<bool> IsUserExists(int userId)
		{
			var user = await _dbContext.Set<User>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId && x.IsEnabled);
			return user != null;
		}

		public async Task<bool> UpdateUserAuthorizationAsync(int userId, IEnumerable<int> roleIds)
		{
			var user = await _dbContext
								.Set<User>()
								.AsNoTracking()
								.Include(p => p.LinkedRoles)
								.SingleAsync(x => x.Id == userId);

			_dbContext.RemoveRange(user.LinkedRoles);

			var listOfUserRoles = new List<UserAuthorization>();

			foreach(var roleId in roleIds)
			{
				listOfUserRoles.Add(new UserAuthorization() { UserId = userId, RoleId = roleId});
			}

			_dbContext.AddRange(listOfUserRoles);
			var t = await _dbContext.SaveChangesAsync();
			return true;
		}
	}
}
