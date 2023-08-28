namespace OnlineMarket.Models.Authentication
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int RoleId { get; set; } // For selecting a role during login
    }
}
