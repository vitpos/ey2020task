using ey2020UserManager.API.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ey2020UserManager.API.Model
{
	public class UserDto
	{
		public int UserId { get; set; }

		[StringLength(ApiConfiguration.NameStringLength)]
		[RegularExpression("^[a-zA-Z][a-zA-Z ,.'-]+$")]
		public string FirstName { get; set; }

		[StringLength(ApiConfiguration.NameStringLength)]
		[RegularExpression("^[a-zA-Z][a-zA-Z ,.'-]+$")]
		public string LastName { get; set; }

		[RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")]
		[StringLength(ApiConfiguration.EmailStringLength)]
		public string Email { get; set; }

		[Phone]
		public string PhoneNumber { get; set; }

		public bool IsEnabled { get; set; }
	}
}
