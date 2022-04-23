using AutoMapper;
using KFCClone.DTOs.Auth;
using KFCClone.DTOs.Checkout;
using KFCClone.Interfaces;
using KFCClone.Models;

namespace KFCClone.Data.Repositories
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CheckoutRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CheckoutDto> GetUserDetailsAsync(string email)
        {
            CheckoutDto checkoutDto = new CheckoutDto();
            
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            
            checkoutDto.UserDetails = _mapper.Map<CheckoutUserDetailsDto>(user);

            return checkoutDto;

        }
    }
}