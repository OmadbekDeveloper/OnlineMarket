// DONE
using OnlineMarket.Models.Dtos.Category;

namespace OnlineMarket.Interfaces.Models
{
    public interface ICategoryService
    {
        Task<Responce<IEnumerable<ResultCategoryDto>>> GetAllCategoriesAsync();
        Task<Responce<ResultCategoryDto>> GetCategoryByIdAsync(int id);
        Task<Responce<ResultCategoryDto>> CreateCategoryAsync(CreateCategoryDto categorydto);
        Task<Responce<IEnumerable<ResultCategoryDto>>> UpdateCategoryAsync(UpdateCategoryDto updatedCategory);
        Task<Responce<bool>> DeleteCategoryAsync(int id);
        // Add more methods as needed
    }
}
