using ey2020UserManager.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ey2020UserManager.Persistence.Repositories
{
	public interface IRepository<T> 
		where T: class, new()
	{
		Task<T> GetByIdAsync(int id);
		IEnumerable<T> GetAll();
		Task AddNewAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
