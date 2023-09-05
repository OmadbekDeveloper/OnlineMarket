
using OnlineMarket.Models.Dtos.Product;

namespace OnlineMarket.Interfaces.Models
{
    public interface IProductService
    {
        public Task<Responce<IEnumerable<ResultProductDto>>> GetProductsAsync();
        Task<Responce<ResultProductDto>> GetProductByIdAsync(int id);
        Task<Responce<IEnumerable<CreateProductDto>>> CreateProductAsync(CreateProductDto productdto);
        Task<Responce<IEnumerable<UpdateProductDto>>> UpdateProductAsync( int id, Product productid);
        Task<Responce<IEnumerable<CreateProductDto>>> DeleteProductAsync(int productid);

    }
}
