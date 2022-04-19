using AutoMapper;
using KFCClone.DTOs.Auth;
using KFCClone.Helpers;
using KFCClone.Interfaces;
using KFCClone.Models;

namespace KFCClone.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;
        public AuthRepository(DataContext context, IMapper mapper, IJwtUtils jwtUtils)
        {
            _context = context;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        public async Task<LoginResponseBodyDto> LoginAsync(LoginRequestBodyDto requestBodyDto)
        {
                
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == requestBodyDto.Email);
             //var user = await _context.Users.FindAsync(requestBodyDto.Email);      

            if (user == null || !BCrypt.Net.BCrypt.Verify(requestBodyDto.Password, user.Password)){
                return new LoginResponseBodyDto{
                    ErrorMessage = "Invalid Email or Password"
                };
            }

            var response = _mapper.Map<LoginResponseBodyDto>(user);

            response.Token = _jwtUtils.GenerateJwt(user);

            response.Country = _context.Countries.SingleOrDefault(x => x.Id == user.CountryId)!.CountryName;
            response.State = _context.States.SingleOrDefault(x => x.Id == user.StateId)!.StateName;
            response.City = _context.Cities.SingleOrDefault(x => x.Id == user.CityId)!.CityName;

            return response;

        }
        
        public async Task<RegisterResponseBodyDto> RegisterAsync(RegisterRequestBodyDto requestBodyDto)
        {
            if (_context.Users.Any(x => x.Email == requestBodyDto.Email))
                throw new ApplicationException("User with this email already exists");

            if (requestBodyDto.Password != requestBodyDto.ConfirmPassword)
                throw new ApplicationException("Passwords do not match");

            List<Country>? country = _context.Countries.Where(x => x.CountryName.ToLower() == requestBodyDto.Country.ToLower()).ToList();
            if (country.Count == 0)
                throw new KeyNotFoundException("Invalid Country");

            List<State>? state = _context.States.Where(x => x.StateName.ToLower() == requestBodyDto.State.ToLower() && x.CountryId == country[0].Id).ToList();
            if (state.Count == 0)
                throw new KeyNotFoundException("Invalid State");

            List<City>? city = _context.Cities.Where(x => x.CityName.ToLower() == requestBodyDto.City.ToLower() && x.StateId == state[0].Id).ToList();
            if (city.Count == 0)
                throw new KeyNotFoundException("Invalid City");

            User user = _mapper.Map<User>(requestBodyDto);

            user.IsGuestUser = false;
            user.CountryId = country[0].Id;
            user.StateId = state[0].Id;
            user.CityId = city[0].Id;
            user.Password = BCrypt.Net.BCrypt.HashPassword(requestBodyDto.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            RegisterResponseBodyDto response = _mapper.Map<RegisterResponseBodyDto>(user);

            response.Country = country[0].CountryName;
            response.State = state[0].StateName;
            response.City = city[0].CityName;

            response.Token = _jwtUtils.GenerateJwt(user);

            return response;
        }
    }
}
