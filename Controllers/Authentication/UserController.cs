using Microsoft.AspNetCore.Mvc;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class AccauntController : ControllerBase
{
    [HttpPost("signup")]
    public IActionResult Signup([FromBody] Customer user)
    {
        if (user == null || string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.Password))
        {
            return BadRequest("Username and password are required.");
        }

        if (CustomerDataStore.Customers.Any(u => u.FirstName == user.FirstName))
        {
            return Conflict("Username already exists.");
        }

        CustomerDataStore.Customers.Add(user);
        return CreatedAtAction(nameof(Login), user);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Customer user)
    {
        if (user == null || string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.Password))
        {
            return BadRequest("Username and password are required.");
        }

        var storedUser = CustomerDataStore.Customers.FirstOrDefault(u => u.FirstName == user.FirstName);

        if (storedUser == null || storedUser.Password != user.Password)
        {
            return Unauthorized("Invalid credentials.");
        }

        return Ok("Login successful.");
    }
}
