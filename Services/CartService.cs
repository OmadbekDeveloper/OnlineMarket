
using OnlineMarket.Models.Models;

public class CartService : ICartService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CartService(OnlineMarketDB context)
    {
        this._unitOfWork = new UnitOfWork(context);

        this._mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile<MapperProfile>()
            ));
    }

    public async Task<Responce<IEnumerable<UniversalCartDto>>> GetAllCartsAsync()
    {
        try
        {
            var getAllCarts = await _unitOfWork.CartRepository.GetAllAsync();

            if (getAllCarts == null)
            {
                return new Responce<IEnumerable<UniversalCartDto>>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Data = null
                };
            }

            var mapper = _mapper.Map<IEnumerable<UniversalCartDto>>(getAllCarts);

            return new Responce<IEnumerable<UniversalCartDto>>
            {
                StatusCode = 200,
                Message = "All products received",
                Data = mapper
            };
        }
        catch (Exception ex)
        {
            return new Responce<IEnumerable<UniversalCartDto>>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<UniversalCartDto>> GetCartByIdAsync(int id)
    {
        try
        {
            var getCartById = _unitOfWork.CartRepository.Get(x => x.CartId == id);


            if (getCartById == null)
            {
                return new Responce<UniversalCartDto>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                };
            }

            var productDtos = _mapper.Map<UniversalCartDto>(getCartById);

            return new Responce<UniversalCartDto>
            {
                StatusCode = 200,
                Message = "All products received",
                Data = productDtos
            };
        }
        catch (Exception ex)
        {
            return new Responce<UniversalCartDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<UniversalCartDto>> CreateCartAsync(UniversalCartDto cartdto)
    {
        try
        {
            var cartcreate = new Cart()
            {
                CartId = cartdto.CartId,
                CustomerId = cartdto.CustomerId,
            };

            _unitOfWork.CartRepository.Add(cartcreate);
            await _unitOfWork.SaveAsync();

            return new Responce<UniversalCartDto>
            {
                StatusCode = 200,
                Message = "Mahsulot muvaffaqiyatli yaratildi",
                Data = null
            };
        }
        catch (Exception ex)
        {
            return new Responce<UniversalCartDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<bool>> DeleteCartAsync(int id)
    {
        try
        {
            var deletecart = _unitOfWork.CartRepository.Get(x => x.CartId == id);

            if (deletecart == null)
            {
                return new Responce<bool>
                {
                    StatusCode = 404,
                    Message = "Cart not found",
                    Data = false
                };
            }

            _unitOfWork.CartRepository.Remove(deletecart);
            await _unitOfWork.CartRepository.SaveAsync();

            return new Responce<bool>
            {
                StatusCode = 200,
                Message = "Cart deleted successfully",
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
