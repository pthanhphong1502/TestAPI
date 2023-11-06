using WebAPI.Models;
using WebAPI.Models.Dtos;

namespace WebAPI.Interface
{
    public interface IOrder
    {
        public Task<List<OrderDto>> GetAllOrderAsync();
        public Task<OrderDto> GetOrderAsync(int id);
        public Task<int> AddOrderAsync(OrderDto model);
        public Task UpdateOrderAsync(int id, OrderDto model);
        public Task DeleteOrderAsync(int id);
    }
}
