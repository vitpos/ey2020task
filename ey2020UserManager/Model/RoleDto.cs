using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ey2020UserManager.API.Model
{
	public class RoleDto
	{
		public int RoleId { get; set; }
		public string RoleName { get; set; }
		public bool IsEnabled { get; set; }
	}
}
