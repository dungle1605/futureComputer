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
    public CreateProductHandler(IRepository<Product> repository,
    MappingProfile<CreateProductCommand, Product> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var filter = new SearchProductSpecification(request.Name);
        var isExistedProduct = await _repository.AnyAsync(filter);
        if (isExistedProduct)
        {
            throw new Exception("Product name is already existed in this system!");
        }
        try
        {
            var extension = Path.GetExtension(request.ImageFile.FileName);
            if (ValidateExtensionFile(extension))
            {
                throw new CreateProductException("Error image file. Please choose again!!!");
            }

            var binaryImage = await ConvertImageToBinary(request.ImageFile);
            var createdAt = DateTime.Now;

            // Save file to local for back-up purpose
            var folderServerName = Path.Combine("Resources", CommonConstant.FOLDER_NAME);

            var product = _mapper.MapperHandler(request);
            product.ImageUrls = "";
            await _repository.AddAsync(product);

            return "Add product successfully";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    private bool ValidateExtensionFile(string extension)
    {
        var lstExtensions = new string[] { ".jpeg", ".png", ".jpg", ".svg" };
        return lstExtensions.Contains(extension);
    }

    private async Task<byte[]> ConvertImageToBinary(IFormFile image)
    {
        using (var dataStream = new MemoryStream())
        {
            await image.CopyToAsync(dataStream);
            return dataStream.ToArray();
        }
    }
}
