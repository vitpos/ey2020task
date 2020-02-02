using ey2020UserManager.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ey2020UserManager.Infrustructure.RoleService
{
	public interface IRoleService
	{
		IEnumerable<Role> GetAllRoles();
		Task<Role> GetRoleByIdAsync();
		Task<bool> UpdateRoleAsync(int id);
		Task<bool> DeleteRoleAsync(int id);
		Task<bool> CreateRoleAsync(int id);
	}
}
