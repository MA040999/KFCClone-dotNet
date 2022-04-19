namespace KFCClone.DTOs.Auth
{
    public class LoginResponseBodyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
        public bool IsGuestUser { get; set; }
        public string ContactNumber { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string? ErrorMessage { get; set; } = null;
    }
}
