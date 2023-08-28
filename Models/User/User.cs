
using OnlineMarket.Models.Authentication;

public class User : IdentityUser
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    // Other properties

    // Foreign Key to Role
    public string RoleId { get; set; }
    public Role Role { get; set; }
}
