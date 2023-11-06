using AutoMapper;
using WebAPI.Models.Dtos;
using WebAPI.Models;
using WebAPI.Interface;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository
{
    public class CatelogyRepository : ICatelogy
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CatelogyRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<int> AddCatelogyAsync(CatelogyDto model)
        {
            var newProduct = _mapper.Map<Catelogy>(model);
            _context.Catelogies.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.CatelogyId;
        }

        public async Task DeleteCatelogyAsync(int id)
        {
            var deleteProduct = _context.Catelogies.SingleOrDefault(x => x.CatelogyId == id);
            if (deleteProduct != null)
            {
                _context.Catelogies.Remove(deleteProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CatelogyDto>> GetAllCatelogyAsync()
        {
            var products = await _context.Catelogies.ToListAsync();
            return _mapper.Map<List<CatelogyDto>>(products);
        }

        public async Task<CatelogyDto> GetCatelogyAsync(int id)
        {
            var products = await _context.Catelogies.FindAsync(id);
            return _mapper.Map<CatelogyDto>(products);
        }

        public async Task UpdateCatelogyAsync(int id, CatelogyDto model)
        {
            if (id == model.CatelogyId)
            {
                var updateProduct = _mapper.Map<Catelogy>(model);
                _context.Catelogies.Update(updateProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
