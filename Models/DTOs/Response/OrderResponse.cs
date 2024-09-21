namespace TestApi.Models.DTOs.Response
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public UserResponse OUserResponse { get; set; }
        public DateTime OrderPurchaseDate { get; set; }
    }
}
