namespace WebAPI.Models.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public int CatelogyId { get; set; }
        public string? ProductName { get; set; }
        public double Weight { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
