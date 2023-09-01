namespace OnlineMarket.Interfaces.Models
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task CreateProductAsync(ProductDto createproductdto);
        Task<bool> UpdateProductAsync( int id, Product productid);
        Task<bool> DeleteProductAsync(int id, Product productid);
        //Task UpdateProductAsync(ProductDto updateProductDto, int id, Product productid);
        //Task DeleteProductAsync(ProductDto deleteProductDto);
    }
}
