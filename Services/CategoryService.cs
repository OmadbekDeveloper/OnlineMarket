
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Models.Dtos.Category;
using OnlineMarket.Models.Models;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(OnlineMarketDB context)
    {
        this._unitOfWork = new UnitOfWork(context);

        this._mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile<MapperProfile>()
            )); ;
    }

    public async Task<Responce<IEnumerable<ResultCategoryDto>>> GetAllCategoriesAsync()
    {
        try
        {
            var getAllCategory = await _unitOfWork.CategoryRepository.GetAllAsync();

            if (getAllCategory == null)
            {
                return new Responce<IEnumerable<ResultCategoryDto>>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Data = null
                };
            }

            var mapper = _mapper.Map<IEnumerable<ResultCategoryDto>>(getAllCategory);

            return new Responce<IEnumerable<ResultCategoryDto>>
            {
                StatusCode = 200,
                Message = "All products received",
                Data = mapper
            };
        }
        catch (Exception ex)
        {
            return new Responce<IEnumerable<ResultCategoryDto>>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<ResultCategoryDto>> GetCategoryByIdAsync(int id)
    {
        try
        {
            var getCategoryById = _unitOfWork.CategoryRepository.Get(x => x.CategoryId == id);


            if (getCategoryById == null)
            {
                return new Responce<ResultCategoryDto>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                };
            }

            var map = _mapper.Map<ResultCategoryDto>(getCategoryById);

            return new Responce<ResultCategoryDto>
            {
                StatusCode = 200,
                Message = "All products received",
                Data = map
            };
        }
        catch(Exception ex)
        {
            return new Responce<ResultCategoryDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<ResultCategoryDto>> CreateCategoryAsync(CreateCategoryDto categorydto)
    {
        try
        {
            var categorycreate = new Category()
            {
                CategoryId = categorydto.CategoryId,
                Name = categorydto.Name,
            };

            _unitOfWork.CategoryRepository.Add(categorycreate);
            await _unitOfWork.SaveAsync();

            return new Responce<ResultCategoryDto>
            {
                StatusCode = 200,
                Message = "Mahsulot muvaffaqiyatli yaratildi",
                Data = null
            };
        }
        catch(Exception ex)
        {
            return new Responce<ResultCategoryDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<IEnumerable<ResultCategoryDto>>> UpdateCategoryAsync(UpdateCategoryDto updatedCategory)
    {
        try
        {
            var existingCategory = _unitOfWork.CategoryRepository.Get(x => x.CategoryId == updatedCategory.CategoryId);

            if (existingCategory == null)
            {
                return new Responce<IEnumerable<ResultCategoryDto>>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                };
            }

            var map = _mapper.Map(updatedCategory, existingCategory);

            _unitOfWork.CategoryRepository.Update(map);
            await _unitOfWork.CategoryRepository.SaveAsync();

            return new Responce<IEnumerable<ResultCategoryDto>>
            {
                StatusCode = 200,
                Message = "Mahsulot yangilandi",
                Data = null
            };
        }
        catch(Exception ex)
        {
            return new Responce<IEnumerable<ResultCategoryDto>>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    }

    public async Task<Responce<bool>> DeleteCategoryAsync(int id)
    {
        try
        {
            var deletecategory = _unitOfWork.CategoryRepository.Get(x => x.CategoryId == id);

            if (deletecategory == null)
            {
                return new Responce<bool>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Data = false
                };
            }

            _unitOfWork.CategoryRepository.Remove(deletecategory);
            await _unitOfWork.CategoryRepository.SaveAsync();

            return new Responce<bool>
            {
                StatusCode = 200,
                Message = "Product deleted successfully",
                Data = true
            };
        }
        catch(Exception ex)
        {
            return new Responce<bool>
            {
                StatusCode = 500,
                Message = "Error",
                Data = false
            };
        }
    }
}
