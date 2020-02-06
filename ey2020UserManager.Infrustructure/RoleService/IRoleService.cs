using ey2020UserManager.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ey2020UserManager.Infrustructure.RoleService
{
	public interface IRoleService
	{
		IEnumerable<Role> GetAllRoles(int page = 0, int size = 10);
		Task<Role> GetRoleByIdAsync(int id);
		Task<int> UpdateRoleAsync(Role id);
		Task DeleteRoleAsync(int id);
		Task<int> CreateRoleAsync(Role entity);
	}
}
