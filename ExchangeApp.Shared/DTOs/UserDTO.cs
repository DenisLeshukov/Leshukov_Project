namespace ExchangeApp.Shared.DTOs
{
    
    public class UserDTO
    {
        public string Name { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string Phone { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateOnly RegistrationDate { get; set; }

        public string? PhotoUrl { get; set; }
    }
    
}
