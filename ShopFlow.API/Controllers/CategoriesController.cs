using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopFlow.API.DTOs;
using ShopFlow.Application.Features.Categories.Commands.CreateCategory;
using ShopFlow.Application.Features.Categories.Queries.GetAllCategory;
using ShopFlow.Application.Features.Categories.Queries.GetCategoryById;
using ShopFlow.Domain.Entity;

namespace ShopFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoryResponse>>> GetAll()
        {
            var categories = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(categories.Select(ToResponse));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid id");
            }
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (category == null)
            {
                return NotFound();
            }
            return Ok(ToResponse(category));
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> Create(CreateCategoryRequest request)
        {
            var id = await _mediator.Send(new CreateCategoryCommand(request.Name, request.Description));
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        private static CategoryResponse ToResponse(Category c)
        {
            return new CategoryResponse(c.Id, c.Name, c.Description, c.CreatedAt);
        }
    }
}
