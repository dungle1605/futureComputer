using System.Net;
using FutureComputer.API.Configuration.Exceptions;
using FutureComputer.Application.Products.Common;
using FutureComputer.Application.Products.CreateProductBySpecificCategory;
using FutureComputer.Application.Products.DeleteProduct;
using FutureComputer.Application.Products.GetAllProducts;
using FutureComputer.Application.Products.GetProductById;
using FutureComputer.Application.Products.GetProductBySearch;
using FutureComputer.Application.Products.UpdateProduct;
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
    public async Task<IActionResult> GetAllProducts()
    {
        var query = new GetAllProductsQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetailsSwaggerResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetProductById([FromRoute] Guid id)
    {
        var query = new GetProductByIdQuery(id);
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("get-products-by-search")]
    [ProducesResponseType(typeof(List<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductBySearch(float price, string categoryName, string prodName)
    {
        var searchQuery = new SearchProductQuery(price, categoryName, prodName);
        var result = await _mediator.Send(searchQuery);

        return Ok(result);
    }

    [HttpPost("create-prod")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetailsSwaggerResponse), (int)HttpStatusCode.BadGateway)]
    public async Task<IActionResult> CreateProductBySpecificCategory([FromBody] CreateProductCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost("update-prod/{id:guid}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetailsSwaggerResponse), (int)HttpStatusCode.BadGateway)]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost("delete-prod/{id:guid}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetailsSwaggerResponse), (int)HttpStatusCode.BadGateway)]
    [ProducesResponseType(typeof(ProblemDetailsSwaggerResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}