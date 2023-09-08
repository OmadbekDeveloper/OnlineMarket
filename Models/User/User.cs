
using OnlineMarket.Models.Authentication;

public class User : IdentityUser, IPerson
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }

    [ForeignKey(nameof(RoleName))]
    public Role Role { get; set; }
    public string RoleName { get; set; }
}
