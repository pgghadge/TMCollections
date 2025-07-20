using Microsoft.AspNetCore.Mvc;
using TMCollections_Api.DTO.Product;
using TMCollections_Api.Services_New.Interfaces;

namespace TMCollections_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task< IActionResult > GetAll()
        {
            var result = await _productService.GetAllProductsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            await _productService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.CategoryId }, new { message = "Product created successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.DeleteAsync(id);
            return Ok(new { message = "Product deleted" });
        }



        [HttpGet("filtered")]
        public async Task<IActionResult> GetFiltered([FromQuery] string? search, [FromQuery] Guid? categoryId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var (products, totalCount) = await _productService.GetFilteredAsync(search, categoryId, page, pageSize);
            return Ok(new
            {
                totalCount,
                page,
                pageSize,
                products
            });
        }

    }
}
