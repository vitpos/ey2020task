using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ey2020UserManager.Persistence.Repositories
{
	public interface IUserAuthorizationRepository
	{
		Task<bool> IsUserExists(int userId);
		bool IsAllRolesExists(IEnumerable<int> roleIds);
		Task<bool> UpdateUserAuthorizationAsync(int userId, IEnumerable<int> roleIds);
	}
}
