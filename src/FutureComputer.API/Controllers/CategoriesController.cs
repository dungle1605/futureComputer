using FutureComputer.API.Configuration.Exceptions;
using FutureComputer.Application.Categories.CategoriesOfTheMonth;
using FutureComputer.Application.Categories.Common;
using FutureComputer.Application.Categories.CreateCategory;
using FutureComputer.Application.Categories.DeleteCategoryById;
using FutureComputer.Application.Categories.GetAllCategories;
using FutureComputer.Application.Categories.GetCategoryById;
using FutureComputer.Application.Categories.UpdateCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("categories-of-the-month")]
        [ProducesResponseType(typeof(List<CategoryResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CategoriesOfTheMonth()
        {
            var query = new GetCategoriesOfTheMonthQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id:guid}"), Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(CategoryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetailsSwaggerResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("create-category")]
        [Authorize]
        [ProducesResponseType(typeof(CategoryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetailsSwaggerResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("delete-category")]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
