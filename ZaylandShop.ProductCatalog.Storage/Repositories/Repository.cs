using Microsoft.EntityFrameworkCore;
using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Storage.Repositories
{
	public abstract class Repository<TEntity> : IRepository<TEntity>
		where TEntity : class, new()
	{
		private protected readonly AppDbContext _dbContext;
		private protected readonly DbSet<TEntity> _dbSet;

		public Repository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
			_dbSet = _dbContext.Set<TEntity>();
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task AddAsync(TEntity entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public async Task UpdateAsync(TEntity entity)
		{
			_dbSet.Update(entity);
		}

		public async Task DeleteAsync(TEntity entity)
		{
			_dbSet.Remove(entity);
		}
	}
}