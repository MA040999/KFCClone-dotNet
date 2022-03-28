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

        public async Task<RegisterResponseBodyDto> RegisterAsync(RegisterRequestBodyDto requestBodyDto)
        {
            if (_context.Users.Any(x => x.Email == requestBodyDto.Email))
                throw new ApplicationException("User with this email already exists");

            if (requestBodyDto.Password != requestBodyDto.ConfirmPassword)
                throw new ApplicationException("Passwords do not match");


            var user = _mapper.Map<User>(requestBodyDto);

            user.Password = BCrypt.Net.BCrypt.HashPassword(requestBodyDto.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<RegisterResponseBodyDto>(user);
        }
    }
}
