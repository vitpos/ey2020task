using ey2020UserManager.Persistence.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

		public async Task<T> GetByIdAsync(int id) => await _dbContext.FindAsync<T>();

		public IEnumerable<T> GetAll() => _dbContext.Set<T>().AsNoTracking();

		public async Task<bool> AddNewAsync(T entity)
		{
			var item = await _dbContext.AddAsync<T>(entity);
			await _dbContext.SaveChangesAsync();

			return item.State == EntityState.Added;
		}
		
		public async Task<bool> DeleteAsync(T entity)
		{
			var item = _dbContext.Remove<T>(entity);
			await _dbContext.SaveChangesAsync();

			return item.State == EntityState.Deleted;
		}

		public async Task<bool> UpdateAsync(T entity)
		{
			var item = _dbContext.Update(entity);
			await _dbContext.SaveChangesAsync();

			return item.State == EntityState.Modified;
		}
	}
}
