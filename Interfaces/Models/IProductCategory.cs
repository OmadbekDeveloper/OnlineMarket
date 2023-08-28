namespace OnlineMarket.Interfaces.Models
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategory>> GetProductCategoriesByProductIdAsync(int productId);
        Task<ProductCategory> AddProductCategoryAsync(int productId, int productCategory);
        Task<bool> RemoveProductCategoryAsync(int productId, int productCategoryId);
        // Add more methods as needed
    }
}
