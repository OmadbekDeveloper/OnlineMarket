
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

    public async Task CreateProductAsync(CreateProductDto productdto)
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

    public async Task<Product> UpdateProductAsync(int id, Product updatedProduct)
    {
        if (id != updatedProduct.ProductId)
            throw new ArgumentException("Id mismatch");

        _context.Entry(updatedProduct).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return updatedProduct;
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            throw new DllNotFoundException("Product not found");

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}
