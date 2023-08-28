using Microsoft.AspNetCore.Cors.Infrastructure;
using OnlineMarket.Interfaces.Models;
using OnlineMarket.Models.Dtos;
using OnlineMarket.Models.Models;

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
        public async Task<IActionResult> GetProducts()
        {
            var getproducts = productService.GetProductsAsync();
            if (getproducts != null)
                return NotFound();

            return Ok(getproducts);
        } // done

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var getproduct = productService.GetProductByIdAsync(id);
            if (getproduct != null)
                return NotFound();

            return Ok(getproduct);
        } // done

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto productdto)
        {
            await productService.CreateProductAsync (productdto);

            return Ok("Created");
        } // done

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int id, Product updatedProduct)
        {
            var updateproduct = productService.UpdateProductAsync(id, updatedProduct);
            if (updatedProduct == null)
                return NotFound();

            return Ok(updatedProduct);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleteproduct = productService.DeleteProductAsync(id);
            if (deleteproduct == null)
                return NotFound();

            return Ok(deleteproduct);
        }
    }
}