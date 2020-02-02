using ey2020UserManager.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ey2020UserManager.Infrustructure.RoleService
{
	public class RoleService : IRoleService
	{
		public Task<bool> CreateRoleAsync(int id) => throw new NotImplementedException();
		public Task<bool> DeleteRoleAsync(int id) => throw new NotImplementedException();
		public IEnumerable<Role> GetAllRoles() => throw new NotImplementedException();
		public Task<Role> GetRoleByIdAsync() => throw new NotImplementedException();
		public Task<bool> UpdateRoleAsync(int id) => throw new NotImplementedException();
	}
}
