namespace WebAPI.Models.Dtos
{
    public class GetAllUserDto
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? CompanyName { get; set; }
        public string? City { get; set;}
        public string? Country { get; set; }
    }
}
