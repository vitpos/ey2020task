using ey2020UserManager.Persistence.Model;
using ey2020UserManager.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ey2020UserManager.Infrustructure.UserService
{
	public class UserService : IUserService
	{
		private readonly IRepository<User> _repository;

		public UserService(IRepository<User> repository)
		{
			_repository = repository;
		}

		public async Task CreateUserAsync(User entity)
			=> await _repository.AddNewAsync(entity);

		public async Task DeleteUserAsync(int id)
		{
			var userToDelete = await _repository.GetByIdAsync(id);
			await _repository.DeleteAsync(userToDelete);
		}

		public IEnumerable<User> GetAllUser()
			=> _repository.GetAll();

		public async Task<User> GetUserByIdAsync(int id)
			=> await _repository.GetByIdAsync(id);

		public Task UpdateUserAsync(User entity)
			=> _repository.UpdateAsync(entity);
	}
}
