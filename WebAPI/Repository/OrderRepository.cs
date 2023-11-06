using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebAPI.Interface;
using WebAPI.Models;
using WebAPI.Models.Dtos;

namespace WebAPI.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<int> AddOrderAsync(OrderDto model)
        {
            var newProduct = _mapper.Map<Order>(model);
            _context.Orders.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.OrderId;
        }
        public async Task DeleteOrderAsync(int id)
        {
            var deleteProduct = _context.Orders.SingleOrDefault(x => x.OrderId == id);
            if (deleteProduct != null)
            {
                _context.Orders.Remove(deleteProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<OrderDto>> GetAllOrderAsync()
        {
            var products = await _context.Orders.ToListAsync();
            return _mapper.Map<List<OrderDto>>(products);
        }

        public async Task<OrderDto> GetOrderAsync(int id)
        {
            var products = await _context.Orders.FindAsync(id);
            return _mapper.Map<OrderDto>(products);
        }

        public async Task UpdateOrderAsync(int id, OrderDto model)
        {
            if (id == model.OrderId)
            {
                var updateProduct = _mapper.Map<Order>(model);
                _context.Orders.Update(updateProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
