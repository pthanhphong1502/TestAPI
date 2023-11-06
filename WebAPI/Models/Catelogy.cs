namespace WebAPI.Models
{
    public class Catelogy
    {
        public int CatelogyId { get; set; }
        public string? CatelogyName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
