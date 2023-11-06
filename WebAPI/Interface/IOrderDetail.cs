using WebAPI.Models.Dtos;

namespace WebAPI.Interface
{
    public interface IOrderDetail
    {
        public Task<List<OrderDetailDto>> GetAllOrderDetailAsync();
        public Task<OrderDetailDto> GetOrderDetailAsync(int id);
        public Task<int> AddOrderDetailAsync(OrderDetailDto model);
        public Task UpdateOrderDetailAsync(int id, OrderDetailDto model);
        public Task DeleteOrderDetailAsync(int id);
    }
}
