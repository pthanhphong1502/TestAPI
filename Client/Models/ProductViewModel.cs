using System.ComponentModel;

namespace Client.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        public string? ProductName { get; set; }
        public double Weight { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
