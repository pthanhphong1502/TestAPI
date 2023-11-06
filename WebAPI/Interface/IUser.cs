using WebAPI.Models.Dtos;

namespace WebAPI.Interface
{
    public interface IUser
    {
        public Task<List<GetAllUserDto>> GetAllUserAsync();
        public Task<GetAllUserDto> GetUserAsync(string Id);
        public Task UpdateUserAsync(string id, GetAllUserDto model);
    }
}
