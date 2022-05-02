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
        private readonly IDropDownListUtils _dropDownListUtils;

        public CheckoutRepository(DataContext context, IMapper mapper, IDropDownListUtils dropDownListUtils)
        {
            _context = context;
            _mapper = mapper;
            _dropDownListUtils = dropDownListUtils;
        }

        public async Task<CheckoutDto> GetUserDetailsAsync(string email)
        {
            CheckoutDto checkoutDto = new CheckoutDto();
            
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            
            bool IsNewGuestUser = false;
            if(user == null){

                user = new User();
                user.Email = email;
                
                IsNewGuestUser = true;
            }

            checkoutDto.UserDetails = _mapper.Map<CheckoutUserDetailsDto>(user);
            checkoutDto.UserDetails = _dropDownListUtils.SetDropDownListValues(checkoutDto.UserDetails);
        
            checkoutDto.UserDetails.FirstName = !string.IsNullOrEmpty(user!.Name) ? user.Name.Split(' ')[0] : "";
            checkoutDto.UserDetails.LastName = !string.IsNullOrEmpty(user!.Name) ? user.Name.Split(' ')[1] : "";

            checkoutDto.UserDetails.IsNewGuestUser = IsNewGuestUser;

            return checkoutDto;

        }

        public Task<CheckoutDto> PlaceOrderAsync(CheckoutDto checkoutDto)
        {
            throw new NotImplementedException();
        }
    }
}