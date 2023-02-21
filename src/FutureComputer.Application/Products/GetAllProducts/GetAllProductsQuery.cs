using FutureComputer.Application.Products.Common;
using MediatR;

namespace FutureComputer.Application.Products.GetAllProducts;

public class GetAllProductsQuery : IRequest<List<ProductResponse>>
{

}