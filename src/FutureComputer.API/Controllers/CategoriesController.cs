using FutureComputer.API.Configuration.Exceptions;
using FutureComputer.Application.Categories.Common;
using FutureComputer.Application.Categories.CreateCategory;
using FutureComputer.Application.Categories.GetAllCategories;
using FutureComputer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FutureComputer.API.Controllers
{
    [Route("/api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-categories")]
        [ProducesResponseType(typeof(List<CategoryResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetailsSwaggerResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command); 
            return Ok(result);
        }
    }
}
