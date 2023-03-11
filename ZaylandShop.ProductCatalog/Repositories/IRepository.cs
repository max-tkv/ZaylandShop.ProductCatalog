namespace ZaylandShop.ProductCatalog.Repositories;

public interface IRepository<TEntity> where TEntity : class, new()
{
    Task<TEntity> GetByIdAsync(long id);
    
    Task<IEnumerable<TEntity>> GetAllAsync();
    
    Task AddAsync(TEntity entity);
    
    Task UpdateAsync(TEntity entity);
    
    Task DeleteAsync(TEntity entity);
}