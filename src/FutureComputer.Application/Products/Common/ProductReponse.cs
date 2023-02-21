namespace FutureComputer.Application.Products.Common;

public class ProductResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string ImageURLs { get; set; }

    public int Quantity { get; set; }

    public string Description { get; set; }
}