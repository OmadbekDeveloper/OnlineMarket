using OnlineMarket.Models.Models;

namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly OnlineMarketDB _context;

        public ProductCategoriesController(OnlineMarketDB context)
        {
            _context = context;
        }

        [HttpGet("GetProductCategories")]
        public async Task<IActionResult> GetProductCategories()
        {
            var productCategories = await _context.ProductCategories.ToListAsync();
            if (productCategories != null)
                return NotFound();

            return Ok(productCategories);
        } // done

        [HttpGet("GetProductCategory")]
        public async Task<IActionResult> GetProductCategory(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (productCategory != null)
                return NotFound();

            return Ok(productCategory);
        } // done

        [HttpPost("CreateProductCategories")]
        public async Task<IActionResult> CreateProductCategory(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductCategory), new { id = productCategory.ProductCategoryId }, productCategory);
        }

        [HttpPut("UpdateProductCategory")]
        public async Task<IActionResult> UpdateProductCategory(int id, ProductCategory updatedProductCategory)
        {
            if (id != updatedProductCategory.ProductCategoryId)
                return BadRequest();

            _context.Entry(updatedProductCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("DeleteProductCategory")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (productCategory == null)
                return NotFound();

            _context.ProductCategories.Remove(productCategory);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}