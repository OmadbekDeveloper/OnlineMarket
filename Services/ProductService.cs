
using Microsoft.EntityFrameworkCore;

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
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    //public async Task<Product> CreateProductAsync(Product product)
    //{
    //    _context.Products.Add(product);
    //    await _context.SaveChangesAsync();
    //    return product;
    //}

    public async Task<Product> CreateProductAsync(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return product;
    }

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
