using KFCClone.DTOs.Auth;

namespace KFCClone.Interfaces
{
    public interface IDropDownListUtils
    {
        public RegisterRequestBodyDto SetDropDownListValues(RegisterRequestBodyDto requestBodyDto);
        public CheckoutUserDetailsDto SetDropDownListValues(CheckoutUserDetailsDto requestBodyDto);
    }
}