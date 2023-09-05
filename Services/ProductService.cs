
using OnlineMarket.Helper;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Responce<IEnumerable<ResultProductDto>>> GetProductsAsync()
    {       
        var getAllProducts = _unitOfWork.ProductRepository.GetAll();
        var productDtos = _mapper.Map<IEnumerable<ResultProductDto>>(getAllProducts);

        return new Responce<IEnumerable<ResultProductDto>>
        {
            StatusCode = 200,
            Message = "Barcha mahsulotlar olindi",
            Data = productDtos
        };


    } // done

    public async Task<Responce<ResultProductDto>> GetProductByIdAsync(int id)
    {
        var getProductById = _unitOfWork.ProductRepository.Get(x=>x.ProductId==id);

        if (getProductById == null)
        {
            return new Responce<ResultProductDto>
            {
                StatusCode = 404,
                Message = "Product not found",
                Data = null
            };
        }

        var productDto = _mapper.Map<ResultProductDto>(getProductById);

        return new Responce<ResultProductDto>
        {
            StatusCode = 200,
            Message = "Mahsulot topildi",
            Data = productDto
        };

    } // done

    public async Task<Responce<IEnumerable<CreateProductDto>>> CreateProductAsync(CreateProductDto productdto)
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
        await _unitOfWork.CommitAsync();

        return new Responce<IEnumerable<CreateProductDto>>
        {
            StatusCode = 200,
            Message = "Mahsulot muvaffaqiyatli yaratildi",
            Data = null
        };
    } // done

    public async Task<Responce<IEnumerable<UpdateProductDto>>> UpdateProductAsync(int id, Product productid)
    {
        var existingProduct = _unitOfWork.ProductRepository.Get(x => x.ProductId == id);

        if (existingProduct == null)
        {
            return new Responce<IEnumerable<UpdateProductDto>>
            {
                StatusCode = 404,
                Message = "Product not found",
                Data = null
            };
        }

        existingProduct.Name = productid.Name;
        existingProduct.Description = productid.Description;
        existingProduct.Price = productid.Price;
        existingProduct.StockQuantity = productid.StockQuantity;

        await _unitOfWork.CommitAsync();

        return new Responce<IEnumerable<UpdateProductDto>>
        {
            StatusCode = 200,
            Message = "Mahsulot yangilandi",
            Data = null
        };
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
            await _unitOfWork.CommitAsync();

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
                Message = $"An error occurred while deleting the product: {ex.Message}",
                Data = false
            };
        }
    }
}
