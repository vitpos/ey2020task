using ey2020UserManager.API.Configuration;
using System.ComponentModel.DataAnnotations;

namespace ey2020UserManager.API.Model
{
	public class RoleDto
	{
		public int RoleId { get; set; }
		[StringLength(ApiConfiguration.NameStringLength)]
		[RegularExpression("^[a-zA-Z][a-zA-Z ,.'-]+$", ErrorMessage = "Incorrect name format.")]
		public string RoleName { get; set; }
		public bool IsEnabled { get; set; }
	}
}
