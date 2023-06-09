﻿using Microsoft.EntityFrameworkCore.Storage;
using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Repositories;
using ZaylandShop.ProductCatalog.Storage.Repositories;

namespace ZaylandShop.ProductCatalog.Storage;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    
    private IDbContextTransaction _transaction;
    
    public IProductRepository Products { get; }
    
    public ICategoryRepository Categories { get; }
    
    public IFileRepository Files { get; }

    public IColorRepository Colors { get; }

    public IBrandRepository Brands { get; }

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        
        Products = new ProductRepository(_dbContext);
        Categories = new CategoryRepository(_dbContext);
        Brands = new BrandRepository(_dbContext);
        Colors = new ColorRepository(_dbContext);
        Files = new FileRepository(_dbContext);
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        await _transaction.RollbackAsync();
        Dispose();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        if (_transaction != null)
        {
            _transaction.Dispose();
            _transaction = null;
        }
    }
}