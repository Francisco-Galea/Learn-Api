﻿namespace TestApi.Models.DTOs.Response
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public CategoryResponse OCategoryResponse { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
