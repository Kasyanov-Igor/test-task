using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test_task.Repositories.Interface;
using Test_task.Services.Interfaces;

namespace Test_task.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private ADatabaseConnection _connection;

		public Repository(ADatabaseConnection connection)
		{
			this._connection = connection;
		}

		public async Task Add(TEntity entity)
		{
			await this._connection.Set<TEntity>().AddAsync(entity);
			await this._connection.SaveChangesAsync();
		}

		public async Task<bool> Delete(int id)
		{
			var gym = await _connection.Set<TEntity>().FindAsync(id);
			if (gym == null) return false;

            this._connection.Set<TEntity>().Remove(gym);
			await this._connection.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<TEntity>> Get()
		{
			return await this._connection.Set<TEntity>().ToListAsync();
		}

		public async Task<TEntity> GetById(int id)
		{
			return await this._connection.Set<TEntity>().FindAsync(id);
		}
	}
}
