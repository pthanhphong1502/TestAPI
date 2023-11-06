using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CatelogyId { get; set; }
        public string? ProductName { get; set; }
        public double Weight { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public Catelogy? Catelogy { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
