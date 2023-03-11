using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Entities;
using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Services;

public class FileService : IFileService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileRepository _fileRepository;

    public FileService(IUnitOfWork unitOfWork, IFileRepository fileRepository)
    {
        _unitOfWork = unitOfWork;
        _fileRepository = fileRepository;
    }

    public async Task AddFileAsync(ProductFile file)
    {
        await _fileRepository.AddAsync(file);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<ICollection<ProductFile>> GetAllFilesAsync()
    {
        var files = await _fileRepository.GetAllAsync();
        return files.ToList();
    }
}