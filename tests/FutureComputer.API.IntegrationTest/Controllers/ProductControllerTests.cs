using FutureComputer.API.IntegrationTest.Configuration;
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
    }

    private void InitProductList()
    {
        var cate1 = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Cate 1"
        };

        var cate2 = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Cate 2"
        };

        var lstProduct = new List<Product>{
            new Product{
                Id = Guid.NewGuid(),
                Price = 1,
                Name = "Prod 1",
                Category = cate1
            },
            new Product{
                Id = Guid.NewGuid(),
                Price = 2,
                Name = "Prod 2",
                Category = cate2
            },
            new Product{
                Id = Guid.NewGuid(),
                Price = 3,
                Name = "Prod 3",
                Category = cate2
            },
            new Product{
                Id = Guid.NewGuid(),
                Price = 4,
                Name = "Prod 4",
                Category = cate1
            },
            new Product{
                Id = Guid.NewGuid(),
                Price = 5,
                Name = "Prod 5",
                Category = cate1
            }
        };

        _fcDbContext.Set<Category>().AddRange(cate1, cate2);
        _fcDbContext.Set<Product>().AddRange(lstProduct);
        _fcDbContext.SaveChanges();
    }
}