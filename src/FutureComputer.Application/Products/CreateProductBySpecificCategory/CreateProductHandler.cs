using FutureComputer.Application.Configs;
using FutureComputer.Application.Products.Common;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FutureComputer.Application.Products.CreateProductBySpecificCategory;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, string>
{
    private readonly IRepository<Product> _repository;
    private readonly MappingProfile<CreateProductCommand, Product> _mapper;
    private readonly ICurrentUserService _currentUser;
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductHandler(IRepository<Product> repository,
    MappingProfile<CreateProductCommand, Product> mapper,
    ICurrentUserService currentUser,
    IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _currentUser = currentUser;
        _unitOfWork = unitOfWork;
    }
    public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var filter = new SearchProductSpecification(request.Name);
        var isExistedProduct = await _repository.AnyAsync(filter, cancellationToken);
        if (isExistedProduct)
        {
            throw new Exception("Product name is already existed in this system!");
        }
        try
        {
            var extension = Path.GetExtension(request.ImageFile.FileName);
            if (!ValidateExtensionFile(extension))
            {
                throw new CreateProductException("Error image file. Please choose again!!!");
            }

            var binaryImage = await ConvertImageToBinary(request.ImageFile);
            var createdAt = DateTime.Now;

            // Save file to local for back-up purpose
            var folderServerName = Path.Combine("Resources", CommonConstant.FOLDER_NAME);
            var localFileName = string.Concat(request.Name.Replace(" ", ""), createdAt.Ticks, extension);
            var staticPath = Path.Combine(Directory.GetCurrentDirectory(), folderServerName);
            if (!Directory.Exists(staticPath))
            {
                Directory.CreateDirectory(staticPath);
            }
            var imagePath = Path.Combine(staticPath, localFileName);
            await File.WriteAllBytesAsync(imagePath, binaryImage, cancellationToken);

            var product = _mapper.MapperHandler(request);
            product.ImageUrls = localFileName;
            product.CreatedBy = _currentUser.Id;
            product.Created = createdAt;

            await _repository.AddAsync(product, cancellationToken);
            _unitOfWork.SaveChange(cancellationToken);

            return "Add product successfully";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    private static bool ValidateExtensionFile(string extension)
    {
        var lstExtensions = new string[] { ".jpeg", ".png", ".jpg", ".svg" };
        return lstExtensions.Contains(extension);
    }

    private static async Task<byte[]> ConvertImageToBinary(IFormFile image)
    {
        using var dataStream = new MemoryStream();
        await image.CopyToAsync(dataStream);
        return dataStream.ToArray();
    }
}
