using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Interface;
using WebAPI.Models.Dtos;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<int> AddProductAsync(ProductDto model)
        {
            var newProduct = _mapper.Map<Product>(model);
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.ProductId;
        }

        public async Task DeleteProductAsync(int id)
        {
            var deleteProduct = _context.Products.SingleOrDefault(x => x.ProductId == id);
            if (deleteProduct != null)
            {
                _context.Products.Remove(deleteProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProductDto>> GetAllProductAsync()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var products = await _context.Products.FindAsync(id);
            return _mapper.Map<ProductDto>(products);
        }

        public async Task UpdateProductAsync(int id, ProductDto model)
        {
            if (id == model.ProductId)
            {
                var updateProduct = _mapper.Map<Product>(model);
                _context.Products.Update(updateProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
