using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopFlow.API.DTOs;
using ShopFlow.Application.Interface;
using ShopFlow.Domain.Entity;

namespace ShopFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoryResponse>>> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories.Select(ToResponse));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid id");
            }
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(ToResponse(category));
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> Create(CreateCategoryRequest request)
        {
            var category = new Category(request.Name, request.Description);
            await _categoryRepository.AddAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, ToResponse(category));
        }

        private static CategoryResponse ToResponse(Category c)
        {
            return new CategoryResponse(c.Id, c.Name, c.Description, c.CreatedAt);
        }
    }
}
