﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.HostedServices;
using ZaylandShop.ProductCatalog.Services;

namespace ZaylandShop.ProductCatalog;

public static class Entry
{
    /// <summary>
    /// Регистрация зависимостей уровня бизнес-логики
    /// </summary>
    /// <param name="serviceCollection">serviceCollection</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<ICategoryService, CategoryService>();
        services.AddTransient<IBrandService, BrandService>();
        services.AddTransient<IColorService, ColorService>();
        services.AddTransient<IFileService, FileService>();
        
        return services;
    }
    
    /// <summary>
    /// Регистрация фоновых заданий
    /// </summary>
    /// <param name="serviceCollection">serviceCollection</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddHostedServices(this IServiceCollection services)
    {
        //services.AddHostedService<TestHostedService>();
        return services;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}