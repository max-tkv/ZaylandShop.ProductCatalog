using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using ZaylandShop.ProductCatalog.Controllers;
using ZaylandShop.ProductCatalog.Controllers.Mappings;
using ZaylandShop.ProductCatalog.Integration.Test.Extensions;
using ZaylandShop.ProductCatalog.Storage;
using ZaylandShop.ProductCatalog.Web.Configuration;
using ZaylandShop.ProductCatalog.Web.Configuration.Swagger;

namespace ZaylandShop.ProductCatalog.Web;

public class Startup
{
    private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfiles(new Profile[]
                {
                    new ProductControllerMappingProfile(),
                    new BrandControllerMappingProfile(),
                    new ColorControllerMappingProfile(),
                    new FileControllerMappingProfile(),
                    new CategoryControllerMappingProfile()
                });
            }).CreateMapper());
            
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            services.AddSqlStorage(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("Db") ?? "");
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddDomain();
            services.AddHostedServices();
            services.AddConfig(_configuration);
            
            services.AddTestHttpApiClient(_configuration);

            services.AddMvc()
                .AddApi()
                .AddValidators()
                .AddControllersAsServices()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                    options.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy(),
                        false));
                });
            
            services.AddSwagger(_configuration);
            services.Configure<AppSwaggerOptions>(_configuration);
            
            var serviceProvider = services.BuildServiceProvider();
            ServiceLocator.SetProvider(serviceProvider);
        }

        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env, 
            IServiceProvider serviceProvider, 
            ILogger<Startup> logger, 
            IHostApplicationLifetime lifetime, 
            IOptions<AppSwaggerOptions> swaggerOptions,
            IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            MigrationsRunner.ApplyMigrations(logger, serviceProvider, "ZaylandShop.ProductCatalog.Web").Wait();
            AppInitializer.Initialize().Wait();
            RegisterLifetimeLogging(lifetime, logger);
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (swaggerOptions.Value.UseSwagger)
            {
                app.UseSwaggerWithVersion(apiVersionDescriptionProvider);
            }
            
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        private static void RegisterLifetimeLogging(IHostApplicationLifetime lifetime, ILogger<Startup> logger)
        {
            lifetime.ApplicationStarted.Register(() => logger.LogInformation("App started"));
            lifetime.ApplicationStopped.Register(() => logger.LogInformation("App stopped"));
        }
}