using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Services;

public class FileService : IFileService
{
    private readonly IUnitOfWork _unitOfWork;

    public FileService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddFileAsync(ProductFile file)
    {
        await _unitOfWork.Files.AddAsync(file);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<ICollection<ProductFile>> GetAllFilesAsync()
    {
        var files = await _unitOfWork.Files.GetAllAsync();
        return files.ToList();
    }

    public async Task<ProductFile?> GetByIdAsync(long id) =>
        await _unitOfWork.Files.GetByIdAsync(id);
}