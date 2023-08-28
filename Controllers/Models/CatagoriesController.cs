// DONE
using OnlineMarket.Interfaces.Models;
using OnlineMarket.Models.Dtos;
using OnlineMarket.Models.Models;

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

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var customers = await categoryService.GetAllCategoriesAsync();
            if (customers == null)
                return NotFound();

            return Ok(customers);
        } // done

        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var getcategory = await categoryService.GetCategoryByIdAsync(id);
            if (getcategory == null)
                return NotFound();

            return Ok(getcategory);
        } // done

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categorydto)
        {
            await categoryService.CreateCategoryAsync(categorydto);
            if(categorydto == null)
                return NotFound();

            return Ok("Created");
        } // done

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(int id, Category updatedCategory)
        {
            var updatecategory = categoryService.UpdateCategoryAsync(id, updatedCategory);
            if (updatecategory == null)
                return NotFound();

            return Ok(updatecategory);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var deletecategory = categoryService.DeleteCategoryAsync(id);
            if (deletecategory == null)
                return NotFound();

            return Ok(deletecategory);
        }
    }
}