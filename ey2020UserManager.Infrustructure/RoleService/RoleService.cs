using ey2020UserManager.Persistence.Model;
using ey2020UserManager.Persistence.Repositories;
using System;
using System.Collections.Generic;
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

		public async Task CreateRoleAsync(Role entity)
			=> await _repository.AddNewAsync(entity);

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
			=> _repository.GetAll();

		public Task<Role> GetRoleByIdAsync(int id)
			=> _repository.GetByIdAsync(id);

		public async Task UpdateRoleAsync(Role entity)
			=> await _repository.UpdateAsync(entity);
	}
}
