using AutoMapper;
using KFCClone.DTOs.AddOn;
using KFCClone.DTOs.Auth;
using KFCClone.DTOs.Cart;
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

            if (user == null)
            {
                user = new User();
                user.Email = email;
            }

            checkoutDto.UserDetails = _mapper.Map<CheckoutUserDetailsDto>(user);
            checkoutDto.UserDetails = _dropDownListUtils.SetDropDownListValues(checkoutDto.UserDetails);

            checkoutDto.UserDetails.FirstName = !string.IsNullOrEmpty(user!.Name) ? user.Name.Split(' ')[0] : "";
            checkoutDto.UserDetails.LastName = !string.IsNullOrEmpty(user!.Name) ? user.Name.Split(' ')[1] : "";

            return checkoutDto;

        }

        public async Task<CheckoutDto?> PlaceOrderAsync(CheckoutDto checkoutDto)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Email == checkoutDto.UserDetails.Email);

            if (user == null)
            {
                Country? country = await _context.Countries.FindAsync(checkoutDto.UserDetails.CountryId);
                if (country == null)
                    throw new BadHttpRequestException("Invalid Country");

                List<State>? state = _context.States.Where(x => x.Id == checkoutDto.UserDetails.StateId && x.CountryId == country.Id).ToList();
                if (state.Count == 0)
                    throw new BadHttpRequestException("Invalid State");

                List<City>? city = _context.Cities.Where(x => x.Id == checkoutDto.UserDetails.CityId && x.StateId == state[0].Id).ToList();
                if (city.Count == 0)
                    throw new BadHttpRequestException("Invalid City");

                user = _mapper.Map<User>(checkoutDto.UserDetails);
                user.IsGuestUser = true;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            else if (!user.IsGuestUser && checkoutDto.IsGuestUser == true)
            {
                throw new BadHttpRequestException("User with this email already exists");
            }
            else
            {
                Country? country = await _context.Countries.FindAsync(checkoutDto.UserDetails.CountryId);
                if (country == null)
                    throw new BadHttpRequestException("Invalid Country");

                List<State>? state = _context.States.Where(x => x.Id == checkoutDto.UserDetails.StateId && x.CountryId == country.Id).ToList();
                if (state.Count == 0)
                    throw new BadHttpRequestException("Invalid State");

                List<City>? city = _context.Cities.Where(x => x.Id == checkoutDto.UserDetails.CityId && x.StateId == state[0].Id).ToList();
                if (city.Count == 0)
                    throw new BadHttpRequestException("Invalid City");

                user.Name = checkoutDto.UserDetails.FirstName + " " + checkoutDto.UserDetails.LastName;
                user.ContactNumber = checkoutDto.UserDetails.ContactNumber;
                user.Address = checkoutDto.UserDetails.Address;
                user.CityId = checkoutDto.UserDetails.CityId;
                user.StateId = checkoutDto.UserDetails.StateId;
                user.CountryId = checkoutDto.UserDetails.CountryId;
                user.IsGuestUser = checkoutDto.IsGuestUser ?? false;

                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            Order order = _mapper.Map<Order>(checkoutDto);
            order.UserId = user.Id;

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            foreach (CartItemDto cartItemDto in checkoutDto.Products)
            {
                OrderProduct orderProduct = _mapper.Map<OrderProduct>(cartItemDto);
                orderProduct.OrderId = order.Id;
                await _context.OrderProducts.AddAsync(orderProduct);

                await _context.SaveChangesAsync();


                if (cartItemDto.Drinks != null)
                {
                    foreach (AddOnDto addOnDto in cartItemDto.Drinks)
                    {
                        OrderProductAddOn orderProductAddOn = _mapper.Map<OrderProductAddOn>(addOnDto);
                        orderProductAddOn.OrderProductId = orderProduct.Id;
                        await _context.OrderProductAddOns.AddAsync(orderProductAddOn);
                    }

                }
                if (cartItemDto.AddOns != null)
                {
                    foreach (AddOnDto addOnDto in cartItemDto.AddOns)
                    {
                        OrderProductAddOn orderProductAddOn = _mapper.Map<OrderProductAddOn>(addOnDto);
                        orderProductAddOn.OrderProductId = orderProduct.Id;
                        await _context.OrderProductAddOns.AddAsync(orderProductAddOn);
                    }

                }
                if (cartItemDto.Upsize != null)
                {
                    foreach (AddOnDto addOnDto in cartItemDto.Upsize)
                    {
                        OrderProductAddOn orderProductAddOn = _mapper.Map<OrderProductAddOn>(addOnDto);
                        orderProductAddOn.OrderProductId = orderProduct.Id;
                        await _context.OrderProductAddOns.AddAsync(orderProductAddOn);
                    }

                }
                if (cartItemDto.FriesSize != null)
                {
                    foreach (AddOnDto addOnDto in cartItemDto.FriesSize)
                    {
                        OrderProductAddOn orderProductAddOn = _mapper.Map<OrderProductAddOn>(addOnDto);
                        orderProductAddOn.OrderProductId = orderProduct.Id;
                        await _context.OrderProductAddOns.AddAsync(orderProductAddOn);
                    }

                }
            }

            await _context.SaveChangesAsync();

            return checkoutDto;

        }
    }
}