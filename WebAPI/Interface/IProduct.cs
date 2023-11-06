using WebAPI.Models;
using WebAPI.Models.Dtos;

namespace WebAPI.Interface
{
    public interface IProduct
    {
        public Task<List<ProductDto>> GetAllProductAsync();
        public Task<ProductDto> GetProductAsync(int id);
        public Task<int> AddProductAsync(ProductDto model);
        public Task UpdateProductAsync(int id, ProductDto model);
        public Task DeleteProductAsync(int id);
    }
}
