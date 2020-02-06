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

			if (userToDelete == null)
			{
				throw new ArgumentException("User doesn't exists in database.");
			}

			await _repository.DeleteAsync(userToDelete);
		}

		public (IEnumerable<User> items, int total) GetAllUser(int page = 0, int size = 10)
			=> _repository.GetAll(page, size);

		public User GetUserById(int id)
			=> _repository.GetByPredicate(item => item.Id == id, new[] { "LinkedRoles.Role" });

		public async Task<int> UpdateUserAsync(User entity)
		{
			var existedUser = await _repository.GetByIdAsync(entity.Id);

			if (existedUser == null && entity.Id > 0)
			{
				throw new ArgumentException("User doesn't exists in database.");
			}

			return (await _repository.UpdateAsync(entity)).Id;
		}
	}
}
