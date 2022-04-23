using KFCClone.DTOs.Auth;
using KFCClone.Interfaces;
using KFCClone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KFCClone.Helpers
{
    public class DropDownListUtils : IDropDownListUtils
    {
        private readonly DataContext _context;

        public DropDownListUtils(DataContext context)
        {
            _context = context;
        }
        
        public RegisterRequestBodyDto SetDropDownListValues(RegisterRequestBodyDto requestBodyDto)
        {
            requestBodyDto.Countries = new SelectList(_context.Countries.Select(x => new Country{
                Id = x.Id,
                CountryName = x.CountryName
            }).ToList(), "Id", "CountryName");
            requestBodyDto.States = new SelectList(_context.States.Select(x => new State{
                Id = x.Id,
                StateName = x.StateName
            }).ToList(), "Id", "StateName");
            requestBodyDto.Cities = new SelectList(_context.Cities.Select(x => new City{
                Id = x.Id,
                CityName = x.CityName
            }).ToList(), "Id", "CityName");

            return requestBodyDto;
        }

        public CheckoutUserDetailsDto SetDropDownListValues(CheckoutUserDetailsDto checkoutUserDetails)
        {
            checkoutUserDetails.Countries = new SelectList(_context.Countries.Select(x => new Country{
                Id = x.Id,
                CountryName = x.CountryName
            }).ToList(), "Id", "CountryName");
            checkoutUserDetails.States = new SelectList(_context.States.Select(x => new State{
                Id = x.Id,
                StateName = x.StateName
            }).ToList(), "Id", "StateName");
            checkoutUserDetails.Cities = new SelectList(_context.Cities.Select(x => new City{
                Id = x.Id,
                CityName = x.CityName
            }).ToList(), "Id", "CityName");

            return checkoutUserDetails;
        }
    }
}