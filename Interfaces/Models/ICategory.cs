// DONE
namespace OnlineMarket.Interfaces.Models
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(int id, Category updatedCategory);
        Task<bool> DeleteCategoryAsync(int id);
        // Add more methods as needed
    }
}
