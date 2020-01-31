using System;
using System.ComponentModel.DataAnnotations;

namespace ey2020UserManager.Persistence.Model
{
	public class User
	{
		[Required]
		[Key]
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		[Required]
		public bool IsEnabled { get; set; }
	}
}
