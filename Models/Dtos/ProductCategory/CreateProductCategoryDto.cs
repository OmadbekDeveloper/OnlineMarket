namespace OnlineMarket.Models.Dtos.ProductCategory
{
    public class CreateProductCategoryDto
    {
        public int ProductCategoryId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
