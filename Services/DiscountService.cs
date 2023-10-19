
using OnlineMarket.Migrations;
using OnlineMarket.Models.Dtos.Discount;

public class DiscountService : IDiscountService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DiscountService(OnlineMarketDB context)
    {
        this._unitOfWork = new UnitOfWork(context);

        this._mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile<MapperProfile>()
            ));
    }
    public async Task<Responce<IEnumerable<ResultDiscountDto>>> GetAllDiscountsAsync()
    {
        try
        {
            var getAllDiscounts = await _unitOfWork.DiscountRepository.GetAllAsync();

            if (getAllDiscounts == null)
            {
                return new Responce<IEnumerable<ResultDiscountDto>>
                {
                    StatusCode = 404,
                    Message = "Not found",
                    Data = null
                };
            }

            var mapper = _mapper.Map<IEnumerable<ResultDiscountDto>>(getAllDiscounts);

            return new Responce<IEnumerable<ResultDiscountDto>>
            {
                StatusCode = 200,
                Message = "All products received",
                Data = mapper
            };
        }
        catch (Exception ex)
        {
            return new Responce<IEnumerable<ResultDiscountDto>>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<ResultDiscountDto>> GetDiscountByIdAsync(int id)
    {
        try
        {
            var getDiscountById = _unitOfWork.DiscountRepository.Get(x => x.DiscountId == id);

            if(getDiscountById == null)
            {
                return new Responce<ResultDiscountDto>
                {
                    StatusCode = 404,
                    Message = "Not Found",

                };
            }

            var discountmap = _mapper.Map<ResultDiscountDto>(getDiscountById);

            return new Responce<ResultDiscountDto>
            {
                StatusCode = 200,
                Message = "all taken out",
                Data = discountmap,
            };
        }
        catch (Exception ex)
        {
            return new Responce<ResultDiscountDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<ResultDiscountDto>> CreateDiscountAsync(CreateDiscountDto discountdto)
    {

        try
        {
            var discountcreate = new Discount()
            {
                DiscountId = discountdto.DiscountId,
                Code = discountdto.Code,
                Type = discountdto.Type,
                Value = discountdto.Value,
                ExpiryDate = discountdto.ExpiryDate,
            };

            _unitOfWork.DiscountRepository.Add(discountcreate);
            await _unitOfWork.DiscountRepository.SaveAsync();

            return new Responce<ResultDiscountDto>
            {
                StatusCode = 200,
                Message = "Mahsulot muvaffaqiyatli yaratildi",
                Data = null
            };
        }
        catch (Exception ex)
        {
            return new Responce<ResultDiscountDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<IEnumerable<ResultDiscountDto>>> UpdateDiscountAsync(UpdateDiscountDto updatedto)
    {
        try
        {
            var existingDiscount = _unitOfWork.DiscountRepository.Get(x => x.DiscountId == updatedto.DiscounntId);

            if (existingDiscount == null)
            {
                return new Responce<IEnumerable<ResultDiscountDto>>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                };
            }

            var map = _mapper.Map(updatedto, existingDiscount);

            _unitOfWork.DiscountRepository.Update(map);
            await _unitOfWork.DiscountRepository.SaveAsync();

            return new Responce<IEnumerable<ResultDiscountDto>>
            {
                StatusCode = 200,
                Message = "Mahsulot yangilandi",
                Data = null
            };
        }
        catch (Exception ex)
        {
            return new Responce<IEnumerable<ResultDiscountDto>>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    }

    public async Task<Responce<bool>> DeleteDiscountAsync(int id)
    {
        try
        {
            var deletecustomer = _unitOfWork.DiscountRepository.Get(x => x.DiscountId == id);

            if (deletecustomer == null)
            {
                return new Responce<bool>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Data = false
                };
            }

            _unitOfWork.DiscountRepository.Remove(deletecustomer);
            await _unitOfWork.DiscountRepository.SaveAsync();

            return new Responce<bool>
            {
                StatusCode = 200,
                Message = "Product deleted successfully",
                Data = true
            };
        }
        catch (Exception ex)
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
