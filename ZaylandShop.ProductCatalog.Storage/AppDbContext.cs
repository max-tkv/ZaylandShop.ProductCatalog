﻿using Microsoft.EntityFrameworkCore;
using ZaylandShop.ProductCatalog.Storage.Configurations;

namespace ZaylandShop.ProductCatalog.Storage;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        base.ChangeTracker.AutoDetectChangesEnabled = true;
        base.Database.AutoTransactionsEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder
            .ApplyConfiguration(new AppUserConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}