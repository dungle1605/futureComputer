using FutureComputer.Application.Products.Common;
using MediatR;

namespace FutureComputer.Application.Products.GetProductBySearch;

public class SearchProductQuery : IRequest<List<ProductResponse>>
{
    public float? Price { get; set; }
    public string CategoryName { get; set; }
    public string Name { get; set; }

    public SearchProductQuery(float? price, string categoryName, string name)
    {
        Price = price;
        CategoryName = categoryName;
        Name = name;
    }
}