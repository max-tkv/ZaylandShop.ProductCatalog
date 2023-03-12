namespace ZaylandShop.ProductCatalog.Repositories;

public interface IRepository<TEntity> where TEntity : class, new()
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    
    Task AddAsync(TEntity entity);
    
    Task UpdateAsync(TEntity entity);
    
    Task DeleteAsync(TEntity entity);
}