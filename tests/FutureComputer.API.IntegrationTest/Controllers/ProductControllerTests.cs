using System.Net;
using FutureComputer.API.IntegrationTest.Configuration;
using FutureComputer.API.IntegrationTest.Helpers;
using FutureComputer.Application.Products.Common;
using FutureComputer.Domain.Entities;

namespace FutureComputer.API.IntegrationTest.Controllers;

public class ProductControllerTests : InMemoryTestBase
{
    private readonly string commonAPI = "api/products";

    public ProductControllerTests(TestingWebAppFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetAllProducts_EmptyList_ReturnProducts()
    {
        InitProductList();

        var response = await _client.GetAsync($"{commonAPI}/get-all-products");
        var result = await IntegrationTestHelper.GetResponseContent<List<ProductResponse>>(response);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(5, result.Count);
    }

    [Theory]
    [InlineData("TestId")]
    public async Task GetProductById_WrongIdFormat_ReturnNotFound(string id)
    {
        InitProductList();

        var response = await _client.GetAsync($"{commonAPI}/{id}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Theory]
    [InlineData("d8cc0fd9-9350-4eac-8691-0167dd22ae0a")]
    public async Task GetProductById_WrongIdFormat_ReturnProductResponse(Guid id)
    {
        InitProductList();

        var response = await _client.GetAsync($"{commonAPI}/{id}");
        var result = await IntegrationTestHelper.GetResponseContent<ProductResponse>(response);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("Prod 2", result.Name);
        Assert.Equal(2, result.Price);
    }

    [Theory]
    [InlineData(-2, "Cate1", "test")]
    public async Task GetProductBySearch_WrongQueryFormat_ReturnBadRequest(float? price, string cateName, string prodName)
    {
        InitProductList();

        var response = await _client.GetAsync($"{commonAPI}/get-products-by-search?price={price}&categoryName={cateName}&prodName={prodName}");

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Theory]
    [InlineData(0, "Cate 1", "test")]
    public async Task GetProductBySearch_ProductBelongToSpecificCategory_ReturnListProductResponse(float? price, string cateName, string prodName)
    {
        InitProductList();

        var response = await _client.GetAsync($"{commonAPI}/get-products-by-search?categoryName={cateName}&name={prodName}");
        var result = await IntegrationTestHelper.GetResponseContent<List<ProductResponse>>(response);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task CreateProductBySpecificCategory_InvalidCategory_ReturnBadRequest()
    {
        InitProductList();

        //var response = 
    }

    //[Fact]
    //public async Task CreateProductCommand_

    private void InitProductList()
    {
        var cate1 = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Cate 1",
            Created = DateTime.Now
        };

        var cate2 = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Cate 2",
            Created = DateTime.Now
        };

        var lstProduct = new List<Product>{
            new Product{
                Id = Guid.NewGuid(),
                Price = 1,
                Name = "Prod 1",
                ImageUrls = "Image 1",
                CategoryId = cate1.Id,
                Created = DateTime.Now
            },
            new Product{
                Id = Guid.Parse("d8cc0fd9-9350-4eac-8691-0167dd22ae0a"),
                Price = 2,
                Name = "Prod 2",
                ImageUrls = "Image 2",
                CategoryId = cate2.Id,
                Created = DateTime.Now
            },
            new Product{
                Id = Guid.NewGuid(),
                Price = 3,
                Name = "Prod 3",
                ImageUrls = "Image 3",
                CategoryId = cate2.Id,
                Created = DateTime.Now
            },
            new Product{
                Id = Guid.NewGuid(),
                Price = 4,
                Name = "Prod 4",
                ImageUrls = "Image 4",
                CategoryId = cate1.Id,
                Created = DateTime.Now
            },
            new Product{
                Id = Guid.NewGuid(),
                Price = 5,
                Name = "Prod 5",
                ImageUrls = "Image 5",
                CategoryId = cate1.Id,
                Created = DateTime.Now
            }
        };

        _fcDbContext.Set<Category>().AddRange(cate1, cate2);
        _fcDbContext.Set<Product>().AddRange(lstProduct);
        _fcDbContext.SaveChanges();
    }
}