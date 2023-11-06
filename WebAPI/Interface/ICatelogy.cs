using WebAPI.Models.Dtos;

namespace WebAPI.Interface
{
    public interface ICatelogy
    {
        public Task<List<CatelogyDto>> GetAllCatelogyAsync();
        public Task<CatelogyDto> GetCatelogyAsync(int id);
        public Task<int> AddCatelogyAsync(CatelogyDto model);
        public Task UpdateCatelogyAsync(int id, CatelogyDto model);
        public Task DeleteCatelogyAsync(int id);
    }
}
