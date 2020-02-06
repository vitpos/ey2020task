using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ey2020UserManager.Persistence.Model
{
	public class UserAuthorization
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int UserId { get; set; }

		[Required]
		public int RoleId { get; set; }

		[ForeignKey("UserId")]
		public User User { get; set; }

		[ForeignKey("RoleId")]
		public Role Role { get; set; }
	}
}
