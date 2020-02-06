using ey2020UserManager.Persistence.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ey2020UserManager.Persistence.Repositories
{
	public class Repository<T> : IRepository<T>
		where T : class, new()
	{
		private readonly UserRoleManagerDbContext _dbContext;

		public Repository(UserRoleManagerDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);

		public T GetByPredicate(Func<T, bool> predicate, string[] includes)
		{
			var item = _dbContext.Set<T>().AsNoTracking();

			foreach (var include in includes)
			{
				item = item.Include(include);
			}

			return item.FirstOrDefault(predicate);
		}

		public IEnumerable<T> GetAll() => _dbContext.Set<T>().AsNoTracking();

		public async Task<T> AddNewAsync(T entity)
		{
			var item = await _dbContext.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return item.Entity;
		}
		
		public async Task DeleteAsync(T entity)
		{
			_dbContext.Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<T> UpdateAsync(T entity)
		{
			var item = _dbContext.Update(entity);
			await _dbContext.SaveChangesAsync();

			return item.Entity;
		}
	}
}
