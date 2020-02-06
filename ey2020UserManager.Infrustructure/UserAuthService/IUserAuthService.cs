using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ey2020UserManager.Infrustructure.UserAuthService
{
	public interface IUserAuthService
	{
		Task UpdateUserAuthAsync(int userId, IEnumerable<int> roles);
	}
}
