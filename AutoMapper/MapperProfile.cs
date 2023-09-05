

namespace OnlineMarket.AutoMapper
{
    public class MapperProfile : Profile
    {

        public MapperProfile() 
        {

            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
        }
    }
}
