using ey2020UserManager.Persistence.Model;
using ey2020UserManager.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ey2020UserManager.Infrustructure.UserAuthService
{
	public class UserAuthService : IUserAuthService
	{
		private readonly IUserAuthorizationRepository _userAuthorizationRepository;

		public UserAuthService(IUserAuthorizationRepository userAuthorizationRepository)
		{
			_userAuthorizationRepository = userAuthorizationRepository;
		}

		public async Task UpdateUserAuthAsync(int userId, IEnumerable<int> roles)
		{
			if (!await _userAuthorizationRepository.IsUserExists(userId))
			{
				throw new ArgumentException("User doesn't exsist or disabled");
			}

			if (!_userAuthorizationRepository.IsAllRolesExists(roles))
			{
				throw new ArgumentException("Incorrect role(s) are present. Please check list of roles");
			}

			await _userAuthorizationRepository.UpdateUserAuthorizationAsync(userId, roles);
		}
	}
}
