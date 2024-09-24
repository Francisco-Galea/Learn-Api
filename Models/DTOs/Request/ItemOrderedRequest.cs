namespace TestApi.Models.DTOs.Request
{
    public class ItemOrderedRequest
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public int OrderId { get; set; }
    }
}
