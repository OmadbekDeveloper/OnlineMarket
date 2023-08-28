// DONE

public class CategoryService : ICategoryService
{
    private readonly OnlineMarketDB _context;

    public CategoryService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        var category1 = await _context.Categories.FirstOrDefaultAsync(cat => cat.Name == category.Name);

        if (category != null)
        {
            throw new Exception("Category with the same name already exists.");
        }

        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<bool> UpdateCategoryAsync(int id, Category updatedCategory)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null)
        {
            throw new Exception("Category not found.");
            return false;
        }

        category.Name = updatedCategory.Name;

        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null)
        {
            throw new Exception("Category not found.");
            return false;
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
}
