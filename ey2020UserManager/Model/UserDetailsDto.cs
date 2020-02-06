using System.Collections.Generic;

namespace ey2020UserManager.API.Model
{
	public class UserDetailsDto
	{
		public int UserId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public IEnumerable<RoleDto> Roles { get; set; }

		public bool IsEnabled { get; set; }
	}
}
