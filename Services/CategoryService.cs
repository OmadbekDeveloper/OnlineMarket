
using OnlineMarket.Models.Dtos.Category;

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
    } // done

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    } // done

    public async Task CreateCategoryAsync(CreateCategoryDto categorydto)
    {
        var categorycreate = new Category()
        {
            CategoryId = categorydto.CategoryId,
            Name = categorydto.Name,
        };

        await _context.Categories.AddAsync(categorycreate);
        await _context.SaveChangesAsync();
    } // done

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
