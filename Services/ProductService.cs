
using AutoMapper;
using OnlineMarket.UnitOfWorks;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(OnlineMarketDB dbcontext)
    {
        this._unitOfWork = new UnitOfWork(dbcontext);

        this._mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile<MapperProfile>()
            ));
    }

    public async Task<Responce<IEnumerable<ResultProductDto>>> GetProductsAsync()
    {
        try
        {

            var getAllProducts = await _unitOfWork.ProductRepository.GetAllAsync();

            if (getAllProducts == null)
            {
                return new Responce<IEnumerable<ResultProductDto>>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Data = null
                };
            }

            var mapper = _mapper.Map<IEnumerable<ResultProductDto>>(getAllProducts);

            return new Responce<IEnumerable<ResultProductDto>>
            {
                StatusCode = 200,
                Message = "All products received",
                Data = mapper
            };
        }
        catch (Exception ex)
        {
            return new Responce<IEnumerable<ResultProductDto>>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<ResultProductDto>> GetProductByIdAsync(int id)
    {
        try
        {
            var getProductById = _unitOfWork.ProductRepository.Get(x => x.ProductId == id);
            

            if (getProductById == null)
            {
                return new Responce<ResultProductDto>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                };
            }

            var productDtos = _mapper.Map<ResultProductDto>(getProductById);

            return new Responce<ResultProductDto>
            {
                StatusCode = 200,
                Message = "All products received",
                Data = productDtos
            };
        }
        catch (Exception ex)
        {
            return new Responce<ResultProductDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }

    } // done

    public async Task<Responce<ResultProductDto>> CreateProductAsync(CreateProductDto productdto)
    {

        try
        {
            var productcreate = new Product()
            {
                ProductId = productdto.ProductId,
                Name = productdto.Name,
                Description = productdto.Description,
                Price = productdto.Price,
                StockQuantity = productdto.StockQuantity,
            };

            _unitOfWork.ProductRepository.Add(productcreate);
            await _unitOfWork.SaveAsync();

            return new Responce<ResultProductDto>
            {
                StatusCode = 200,
                Message = "Mahsulot muvaffaqiyatli yaratildi",
                Data = null
            };
            //var productcreate = _unitOfWork.ProductRepository.GetByNameAsync(productdto.Name);

            //if(productcreate == null)
            //{
            //    return new Responce<ResultProductDto>
            //    {
            //        StatusCode = 403,
            //        Message = "This Product is already",
            //    };
            //}

            //var mapper = _mapper.Map<Product>(productdto);

            //await _unitOfWork.ProductRepository.CreateAsync(mapper);

            //return new Responce<ResultProductDto>
            //{
            //    StatusCode = 200,
            //    Message = "Product created successfully",
            //    Data = null
            //};
        }
        catch (Exception ex)
        {
            return new Responce<ResultProductDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<IEnumerable<ResultProductDto>>> UpdateProductAsync( UpdateProductDto productid)
    {
        try
        {

            var existingProduct = _unitOfWork.ProductRepository.Get(x => x.ProductId == productid.Id);

            if (existingProduct == null)
            {
                return new Responce<IEnumerable<ResultProductDto>>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                };
            }

            var map = _mapper.Map(productid, existingProduct);

            _unitOfWork.ProductRepository.Update(map);
            await _unitOfWork.ProductRepository.SaveAsync();

            return new Responce<IEnumerable<ResultProductDto>>
            {
                StatusCode = 200,
                Message = "Mahsulot yangilandi",
                Data = null
            };
        }
        catch (Exception ex)
        {
            return new Responce<IEnumerable<ResultProductDto>>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    }

    public async Task<Responce<bool>> DeleteProductAsync(int productid)
    {
        try
        {
            var deleteproduct = _unitOfWork.ProductRepository.Get(x => x.ProductId == productid);

            if (deleteproduct == null)
            {
                return new Responce<bool>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Data = false
                };
            }

            _unitOfWork.ProductRepository.Remove(deleteproduct);
            await _unitOfWork.ProductRepository.SaveAsync();

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
    } // done
}
