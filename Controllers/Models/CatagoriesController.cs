
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
        public async Task<Responce<IEnumerable<ResultCategoryDto>>> GetAllCategories()
        {
            var customers = await categoryService.GetAllCategoriesAsync();

            return customers;
        } // done

        [HttpGet("GetCategoryById")]
        public async Task<Responce<ResultCategoryDto>> GetCategoryById(int id)
        {
            var getcategory = await categoryService.GetCategoryByIdAsync(id);

            return getcategory;
        } // done

        [HttpPost("CreateCategory")]
        public async Task<Responce<ResultCategoryDto>> CreateCategory(CreateCategoryDto categorydto)
        {
            var createcategory = await categoryService.CreateCategoryAsync(categorydto);

            return createcategory;
        } // done

        [HttpPut("UpdateCategory")]
        public async Task<Responce<IEnumerable<ResultCategoryDto>>> UpdateCategory(UpdateCategoryDto updatedCategory)
        {
            var updatecategory = await categoryService.UpdateCategoryAsync(updatedCategory);

            return updatecategory;
        }

        [HttpDelete("DeleteCategory")]
        public async Task<Responce<bool>> DeleteCategory(int id)
        {
            var deletecategory = await categoryService.DeleteCategoryAsync(id);

            return deletecategory;
        }
    }
}