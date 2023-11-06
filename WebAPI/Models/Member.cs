using Microsoft.AspNetCore.Identity;

namespace WebAPI.Models
{
    public class Member : IdentityUser
    {
        public string? CompanyName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
