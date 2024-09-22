namespace TestApi.Models.DTOs.Response
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public CategoryResponse OCategory { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
    }
}
