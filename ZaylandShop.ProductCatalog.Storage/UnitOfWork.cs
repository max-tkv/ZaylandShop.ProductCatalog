using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Repositories;
using ZaylandShop.ProductCatalog.Storage.Repositories;

namespace ZaylandShop.ProductCatalog.Storage;

public class UnitOfWork : IUnitOfWork
{
    public IAppUserRepository Users { get; }

    private readonly AppDbContext _appDbContext;
    private bool _isDisposed;
    
    public UnitOfWork([NotNull] AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;

        Users = new AppUserRepository(appDbContext);
    }

    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        _isDisposed = true;
        _appDbContext.Dispose();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        _appDbContext.ChangeTracker.DetectChanges();
        return await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public Task DetachAllTrackingEntitiesAsync()
    {
        foreach (var entityEntry in _appDbContext.ChangeTracker.Entries())
        {
            _appDbContext.Attach(entityEntry.Entity).State = EntityState.Detached;
        }
        return Task.CompletedTask;
    }
}