public class CartItemService : ICartItemService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CartItemService(OnlineMarketDB context)
    {
        this._unitOfWork = new UnitOfWork(context);

        this._mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile<MapperProfile>()
            ));
    }

    public async Task<Responce<IEnumerable<ResultCartItemDto>>> GetCartItemAllAsync()
    {
        try
        {

            var getAllCartItems = await _unitOfWork.CartItemRepository.GetAllAsync();

            if (getAllCartItems == null)
            {
                return new Responce<IEnumerable<ResultCartItemDto>>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Data = null
                };
            }

            var mapper = _mapper.Map<IEnumerable<ResultCartItemDto>>(getAllCartItems);

            return new Responce<IEnumerable<ResultCartItemDto>>
            {
                StatusCode = 200,
                Message = "All products received",
                Data = mapper
            };
        }
        catch (Exception ex)
        {
            return new Responce<IEnumerable<ResultCartItemDto>>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };


        }

    } // done

    public async Task<Responce<ResultCartItemDto>> GetCartItemByIdAsync(int id)
    {
        try
        {
            var getCartItemById = _unitOfWork.CartItemRepository.Get(x => x.CartItemId == id);


            if (getCartItemById == null)
            {
                return new Responce<ResultCartItemDto>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                };
            }

            var cartitemDtos = _mapper.Map<ResultCartItemDto>(getCartItemById);

            return new Responce<ResultCartItemDto>
            {
                StatusCode = 200,
                Message = "All products received",
                Data = cartitemDtos
            };
        }
        catch (Exception ex)
        {
            return new Responce<ResultCartItemDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<ResultCartItemDto>> AddCartItemAsync(CreateCartItemDto cartItemdto)
    {
        try
        {
            var cartitemtcreate = new CartItem()
            {
                CartItemId = cartItemdto.CartItemId,
                CartId = cartItemdto.CartId,
                ProductId = cartItemdto.ProductId,
                Quantity = cartItemdto.Quantity,

            };

            await _unitOfWork.CartItemRepository.AddAsync(cartitemtcreate);
            await _unitOfWork.SaveAsync();

            return new Responce<ResultCartItemDto>
            {
                StatusCode = 200,
                Message = "Mahsulot muvaffaqiyatli yaratildi",
                Data = null
            };
        }
        catch (Exception ex)
        {
            return new Responce<ResultCartItemDto>
            {
                StatusCode=400,
                Message = "Bad Request",
            };
            return new Responce<ResultCartItemDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }

    } // done

    public async Task<Responce<ResultCartItemDto>> UpdateCartItemAsync(UpdateCartItemDto cartitem)
    {
        try
        {
            var updatecart = _unitOfWork.CartItemRepository.Get(x => x.CartItemId == cartitem.CartItemId);

            if (updatecart == null)
            {
                return new Responce<ResultCartItemDto>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                };
            }

            var mapper = _mapper.Map(cartitem, updatecart);

            _unitOfWork.CartItemRepository.Update(mapper);
            await _unitOfWork.CartItemRepository.SaveAsync();

            return new Responce<ResultCartItemDto>
            {
                StatusCode = 200,
                Message = "Mahsulot yangilandi",
                Data = null
            };
        }
        catch (Exception ex)
        {
            return new Responce<ResultCartItemDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    }


    public async Task<Responce<bool>> RemoveCartItemAsync(int id)
    {
        try
        {
            var deletecartitem = _unitOfWork.CartItemRepository.Get(x => x.CartItemId == id);

            if (deletecartitem == null)
            {
                return new Responce<bool>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Data = false
                };
            }

            _unitOfWork.CartItemRepository.Remove(deletecartitem);
            await _unitOfWork.CartItemRepository.SaveAsync();

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
