namespace TestApi.Models.DTOs.Response
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public string? UserEmail { get; set; }

    }
}
