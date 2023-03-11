using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Abstractions;

public interface IUnitOfWork : IDisposable
{
    IAppUserRepository Users { get; }
}