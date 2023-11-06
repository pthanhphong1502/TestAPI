using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
