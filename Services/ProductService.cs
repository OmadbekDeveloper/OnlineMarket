
using OnlineMarket.Models.Models;

public class ProductService : IProductService
{
    private readonly OnlineMarketDB _context;

    public ProductService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    } // done

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    } // done

    public async Task CreateProductAsync(ProductDto productdto)
    {
        var productcreate = new Product()
        {
            ProductId = productdto.ProductId,
            Name = productdto.Name,
            Description = productdto.Description,
            Price = productdto.Price,
            StockQuantity = productdto.StockQuantity,
        };

        await _context.Products.AddAsync(productcreate);
        await _context.SaveChangesAsync();
    } // done

    //public async Task UpdateProductAsync(ProductDto updateProductDto, int id, Product productid)
    //{
    //    //try
    //    //{
    //    //    var productupdate = await _context.Products.FindAsync(id, productid.ProductId);

    //    //    if (productupdate == null)
    //    //    {
    //    //        throw new Exception("Payment not found.");
    //    //    }

    //    //    productupdate = new Product()
    //    //    {
    //    //        ProductId = updateProductDto.ProductId,
    //    //        Name = updateProductDto.Name,
    //    //        Description = updateProductDto.Description,
    //    //        Price = updateProductDto.Price,
    //    //        StockQuantity = updateProductDto.StockQuantity,
    //    //    };

    //    //    _context.Products.Update(productupdate);
    //    //    await _context.SaveChangesAsync();
    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    Console.WriteLine("Error product update");
    //    //}

    //}

    public async Task<bool> UpdateProductAsync(int id, Product productid)
    {
        var existingOrder = await _context.Products.FindAsync(id);

        if (existingOrder == null)
        {
            throw new Exception("Order not found.");
            return false;
        }



        _context.Products.Update(existingOrder);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteProductAsync(int id, Product productid)
    {
        var order = await _context.Products.FindAsync(id);

        if (order == null)
        {
            throw new Exception("Order not found.");
            return false;
        }

        _context.Products.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }
}
