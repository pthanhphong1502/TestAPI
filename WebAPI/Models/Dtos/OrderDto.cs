﻿namespace WebAPI.Models.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string? MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal Freight { get; set; }
    }
}
