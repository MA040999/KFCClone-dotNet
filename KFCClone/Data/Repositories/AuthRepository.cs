using AutoMapper;
using KFCClone.DTOs.Auth;
using KFCClone.Models;

namespace KFCClone.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AuthRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<RegisterResponseBodyDto> RegisterAsync(RegisterRequestBodyDto requestBodyDto)
        //{

        //    var user = _mapper.Map<User>(requestBodyDto);
        //    await _context.Users.AddAsync(user);
        //    await _context.SaveChangesAsync();

        //    return _mapper.Map<RegisterResponseBodyDto>(user);
        //}
    }
}
