using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Interface;
using WebAPI.Models;
using WebAPI.Models.Dtos;

namespace WebAPI.Repository
{
    public class OrderDetailRepository : IOrderDetail
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderDetailRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<int> AddOrderDetailAsync(OrderDetailDto model)
        {
            var newProduct = _mapper.Map<OrderDetail>(model);
            _context.OrderDetails.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.OrderId;
        }
        public async Task DeleteOrderDetailAsync(int id)
        {
            var deleteProduct = _context.OrderDetails.SingleOrDefault(x => x.OrderId == id);
            if (deleteProduct != null)
            {
                _context.OrderDetails.Remove(deleteProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<OrderDetailDto>> GetAllOrderDetailAsync()
        {
            var products = await _context.OrderDetails.ToListAsync();
            return _mapper.Map<List<OrderDetailDto>>(products);
        }

        public async Task<OrderDetailDto> GetOrderDetailAsync(int id)
        {
            var products = await _context.OrderDetails.FindAsync(id);
            return _mapper.Map<OrderDetailDto>(products);
        }

        public async Task UpdateOrderDetailAsync(int id, OrderDetailDto model)
        {
            if (id == model.OrderId)
            {
                var updateProduct = _mapper.Map<OrderDetail>(model);
                _context.OrderDetails.Update(updateProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
