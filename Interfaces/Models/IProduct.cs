
using OnlineMarket.Models.Dtos.Product;

namespace OnlineMarket.Interfaces.Models
{
    public interface IProductService
    {
        public Task<Responce<IEnumerable<ResultProductDto>>> GetProductsAsync();
        Task<Responce<ResultProductDto>> GetProductByIdAsync(int id);
        Task<Responce<IEnumerable<CreateProductDto>>> CreateProductAsync(CreateProductDto createproductdto);
        Task<Responce<IEnumerable<UpdateProductDto>>> UpdateProductAsync( int id, Product productid);
        Task<Responce<bool>> DeleteProductAsync(int productid);
        //Task UpdateProductAsync(ProductDto updateProductDto, int id, Product productid);
        //Task DeleteProductAsync(ProductDto deleteProductDto);
    }
}
