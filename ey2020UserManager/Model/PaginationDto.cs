using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ey2020UserManager.API.Model
{
	public class PaginationDto<T>
	{
		public int Page { get; set; }
		public int Size { get; set; }
		public int Total { get; set; }
		public IEnumerable<T> Data { get; set; }
	}
}
