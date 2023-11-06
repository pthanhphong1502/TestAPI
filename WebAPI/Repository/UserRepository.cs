using AutoMapper;
using WebAPI.Interface;
using WebAPI.Models.Dtos;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllUserDto>> GetAllUserAsync()
        {
            var users = await _context.Members.ToListAsync();
            return _mapper.Map<List<GetAllUserDto>>(users);
        }

        public async Task<GetAllUserDto> GetUserAsync(string id)
        {
            var users = await _context.Members.FindAsync(id);
            return _mapper.Map<GetAllUserDto>(users);
        }

        public async Task UpdateUserAsync(string id, GetAllUserDto model)
        {
            if (id == model.Id)
            {
                var updateUsers = _mapper.Map<Member>(model);
                _context.Members.Update(updateUsers);
                await _context.SaveChangesAsync();
            }
        }
    }
}

