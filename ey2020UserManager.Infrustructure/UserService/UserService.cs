using ey2020UserManager.Persistence.Model;
using ey2020UserManager.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public async Task<int> CreateUserAsync(User entity)
		{
			var user = await _repository.AddNewAsync(entity);
			return user.Id;
		}

		public async Task DeleteUserAsync(int id)
		{
			var userToDelete = await _repository.GetByIdAsync(id);

			// TODO: Should throw an exception "Entity is not exists. Bad request"
			await _repository.DeleteAsync(userToDelete);
		}

		public IEnumerable<User> GetAllUser()
			=> _repository.GetAll() ?? Enumerable.Empty<User>();

		public async Task<User> GetUserByIdAsync(int id)
			=> await _repository.GetByIdAsync(id);

		public async Task<int> UpdateUserAsync(User entity)
		{
			var user = await _repository.UpdateAsync(entity);
			return user.Id;
		}
	}
}
