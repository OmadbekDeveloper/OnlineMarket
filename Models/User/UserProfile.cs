using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Models.User
{
    public class UserProfileUpdateModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        // Add other properties for updating the user profile, if needed
    }
}
