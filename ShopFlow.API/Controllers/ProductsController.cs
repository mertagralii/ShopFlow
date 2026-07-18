using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopFlow.API.DTOs;
using ShopFlow.Application.Interface;
using ShopFlow.Domain.Entity;

namespace ShopFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductResponse>>> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products.Select(ToResponse));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid id");
            }

            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(ToResponse(product));
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponse>> Create(CreateProductRequest request)
        {
            var product = new Product(request.CategoryId, request.Name, request.Price, request.Stock, request.Description);
            await _productRepository.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, ToResponse(product));
        }

        private static ProductResponse ToResponse(Product p)
        {
            return new ProductResponse(p.Id, p.CategoryId, p.Name, p.Price, p.Stock, p.Description, p.IsActive, p.CreatedAt);
        }
            
}
}
