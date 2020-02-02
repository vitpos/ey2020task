﻿using ey2020UserManager.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ey2020UserManager.Infrustructure.UserService
{
	public interface IUserService
	{
		IEnumerable<User> GetAllUser();
		Task<User> GetUserByIdAsync(int id);
		Task UpdateUserAsync(User id);
		Task DeleteUserAsync(int id);
		Task CreateUserAsync(User entity);
	}
}
