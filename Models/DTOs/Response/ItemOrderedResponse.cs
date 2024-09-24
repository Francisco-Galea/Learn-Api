namespace TestApi.Models.DTOs.Response
{
    public class ItemOrderedResponse
    {
        public int ItemOrderedId { get; set; }
        public ProductResponse OProductResponse { get; set; }
        public int ProductQuantity { get; set; }
    }
}
