
public class ProductCategoryService : IProductCategoryService
{
    private readonly OnlineMarketDB _context;

    public ProductCategoryService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<ProductCategory>> GetProductCategoriesByProductIdAsync(int productId)
    {
        return await _context.ProductCategories.ToListAsync();
    } // done

    public async Task<ProductCategory> AddProductCategoryAsync(int productId, int categoryId)
    {
        var existingProduct = await _context.Products.FindAsync(productId);
        var existingCategory = await _context.Categories.FindAsync(categoryId);

        if (existingProduct == null || existingCategory == null)
        {
            throw new Exception("Product or category not found.");
        }

        var productCategory = new ProductCategory
        {
            ProductId = productId,
            CategoryId = categoryId
        };

        _context.ProductCategories.Add(productCategory);
        await _context.SaveChangesAsync();

        return productCategory;
    }

    public async Task<bool> RemoveProductCategoryAsync(int productId, int categoryId)
    {
        var productCategory = await _context.ProductCategories
            .FirstOrDefaultAsync(pc => pc.ProductId == productId && pc.CategoryId == categoryId);

        if (productCategory == null)
        {
            throw new Exception("Product category association not found.");
            return false;
        }

        _context.ProductCategories.Remove(productCategory);
        await _context.SaveChangesAsync();
        return true;
    }
}
