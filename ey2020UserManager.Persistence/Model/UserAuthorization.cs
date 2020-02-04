using System;
using System.Collections.Generic;
using System.Text;

namespace ey2020UserManager.Persistence.Model
{
	public class UserAuthorization
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int RoleId { get; set; }

		public User User { get;  set; }
		public Role Role { get; set; }
	}
}
