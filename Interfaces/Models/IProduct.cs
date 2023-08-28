namespace OnlineMarket.Interfaces.Models
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task CreateProductAsync(CreateProductDto productdto);
        Task<Product> UpdateProductAsync(int id, Product updatedProduct);
        Task DeleteProductAsync(int id);
    }
}
