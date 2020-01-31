using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ey2020UserManager.Persistence.Model
{
	public class Role
	{
		[Required]
		[Key]
		public int Id { get; set; }

		[Required]
		public string RoleKey { get; set; }

		[Required]
		public bool IsActive { get; set; }
	}
}
