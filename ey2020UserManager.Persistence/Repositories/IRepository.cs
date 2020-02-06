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
		T GetByPredicate(Func<T, bool> predicate, string[] includes);
		Task<T> AddNewAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
