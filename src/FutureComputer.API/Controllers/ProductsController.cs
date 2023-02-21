using System.Net;
using FutureComputer.API.Configuration.Exceptions;
using FutureComputer.Application.Products.Common;
using FutureComputer.Application.Products.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FutureComputer.API.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all-products")]
    [ProducesResponseType(typeof(List<ProductResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetailsSwaggerResponse), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetAllProducts()
    {
        var query = new GetAllProductsQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}