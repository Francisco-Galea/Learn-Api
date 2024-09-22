namespace TestApi.Models.DTOs.Request
{
    public class ProductRequest
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
    }
}
