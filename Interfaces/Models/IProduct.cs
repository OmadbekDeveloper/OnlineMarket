
using OnlineMarket.Models.Dtos.Product;

namespace OnlineMarket.Interfaces.Models
{
    public interface IProductService
    {
        public Task<Responce<IEnumerable<ResultProductDto>>> GetProductsAsync();
        Task<Responce<ResultProductDto>> GetProductByIdAsync(int id);
        Task<Responce<ResultProductDto>> CreateProductAsync(CreateProductDto productdto);
        Task<Responce<IEnumerable<ResultProductDto>>> UpdateProductAsync(UpdateProductDto productid);
        Task<Responce<bool>> DeleteProductAsync(int productid);

    }
}
