
namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("GetProducts")]
        public async Task<Responce<IEnumerable<ResultProductDto>>> GetProducts()
        {
            var getproducts = await productService.GetProductsAsync();

            return getproducts;
        } // done

        [HttpGet("GetProduct")]
        public async Task<Responce<ResultProductDto>> GetProduct(int id)
        {
            var getproduct = await productService.GetProductByIdAsync(id);

            return getproduct;
        } // done

        [HttpPost("CreateProduct")]
        public async Task<Responce<IEnumerable<CreateProductDto>>> CreateProduct(CreateProductDto productdto)
        {
            var createproduct = await productService.CreateProductAsync(productdto);

            return createproduct;
        } // done

        [HttpPut("UpdateProduct")]
        public async Task<Responce<IEnumerable<UpdateProductDto>>> UpdateProduct(int id, Product productid)
        {
            var updateproduct = await productService.UpdateProductAsync(id, productid);

            return updateproduct;
        }

        [HttpDelete("DeleteProduct")]
        public async Task<Responce<IEnumerable<CreateProductDto>>> DeleteProduct(int productid)
        {
            var deleteproduct = await productService.DeleteProductAsync(productid);

            return deleteproduct;
        }
    }
}
