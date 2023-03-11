using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Storage.Repositories;

public class AppUserRepository : Repository<Entities.AppUser>, IAppUserRepository
{
    public AppUserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Entities.AppUser> AddAsync(Entities.AppUser newUser)
    {
        var userEntity = await DbSet.AddAsync(newUser);
        return userEntity.Entity;
    }
}