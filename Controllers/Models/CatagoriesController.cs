// DONE
namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("{GetAllCategories}")]
        public async Task<IActionResult> GetAllCategories()
        {
            var getcategories = categoryService.GetAllCategoriesAsync();
            return Ok(getcategories);
        }

        [HttpGet("{GetCategoryById}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var getcategory = categoryService.GetCategoryByIdAsync(id);
            if (getcategory == null)
                return NotFound();

            return Ok(getcategory);
        }

        [HttpPost("{CreateCategory}")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            var createcategory = categoryService.CreateCategoryAsync(category);
            if (createcategory == null)
                return NotFound();

            return Ok(createcategory);
        }

        [HttpPut("{UpdateCategory}")]
        public async Task<IActionResult> UpdateCategory(int id, Category updatedCategory)
        {
            var updatecategory = categoryService.UpdateCategoryAsync(id, updatedCategory);
            if (updatecategory == null)
                return NotFound();

            return Ok(updatecategory);
        }

        [HttpDelete("{DeleteCategory}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var deletecategory = categoryService.DeleteCategoryAsync(id);
            if (deletecategory == null)
                return NotFound();

            return Ok(deletecategory);
        }
    }
}