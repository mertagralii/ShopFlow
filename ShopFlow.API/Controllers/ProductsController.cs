using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopFlow.API.DTOs;
using ShopFlow.Application.Features.Products.Commands.CreateProduct;
using ShopFlow.Application.Features.Products.Queries;
using ShopFlow.Application.Features.Products.Queries.GetProductById;
using ShopFlow.Application.Interface;
using ShopFlow.Domain.Entity;

namespace ShopFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductResponse>>> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products.Select(ToResponse));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid id");
            }

            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(ToResponse(product));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var id = await _mediator.Send(new CreateProductCommand(request.CategoryId, request.Name, request.Price, request.Stock, request.Description));
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        private static ProductResponse ToResponse(Product p)
        {
            return new ProductResponse(p.Id, p.CategoryId, p.Name, p.Price, p.Stock, p.Description, p.IsActive, p.CreatedAt);
        }

    }
}
