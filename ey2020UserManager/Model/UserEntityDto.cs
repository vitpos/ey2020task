using ey2020UserManager.API.Configuration;
using System.ComponentModel.DataAnnotations;

namespace ey2020UserManager.API.Model
{
	public class UserEntityDto
	{
		[Required]
		[StringLength(ApiConfiguration.NameStringLength)]
		[RegularExpression("^[a-zA-Z][a-zA-Z ,.'-]+$", ErrorMessage = "Incorrect name format.")]
		public string FirstName { get; set; }

		[Required]
		[StringLength(ApiConfiguration.NameStringLength)]
		[RegularExpression("^[a-zA-Z][a-zA-Z ,.'-]+$", ErrorMessage = "Incorrect lastname format.")]
		public string LastName { get; set; }

		[RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage = "Incorrect Email format.")]
		[StringLength(ApiConfiguration.EmailStringLength)]
		public string Email { get; set; }

		[Phone(ErrorMessage = "Incorrect phone format.")]
		[StringLength(ApiConfiguration.PhoneStringLength, ErrorMessage = "Exceed phone limit.")]
		public string PhoneNumber { get; set; }

		public bool IsEnabled { get; set; }
	}
}
