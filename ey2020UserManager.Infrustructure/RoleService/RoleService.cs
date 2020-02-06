using ey2020UserManager.Persistence.Model;
using ey2020UserManager.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ey2020UserManager.Infrustructure.RoleService
{
	public class RoleService : IRoleService
	{
		private readonly IRepository<Role> _repository;

		public RoleService(IRepository<Role> repository)
		{
			_repository = repository;
		}

		public async Task<int> CreateRoleAsync(Role entity)
		{
			var role = await _repository.AddNewAsync(entity);
			return role.Id;
		}

		public async Task DeleteRoleAsync(int id)
		{
			var role = await _repository.GetByIdAsync(id);

			if(role == null)
			{
				return;
			}

			await _repository.DeleteAsync(role);
		}
		
		public IEnumerable<Role> GetAllRoles()
			=> _repository.GetAll() ?? Enumerable.Empty<Role>();

		public async Task<Role> GetRoleByIdAsync(int id)
			=> await _repository.GetByIdAsync(id);

		public async Task<int> UpdateRoleAsync(Role entity)
		{
			var role = await _repository.UpdateAsync(entity);
			return role.Id;
		}
	}
}
