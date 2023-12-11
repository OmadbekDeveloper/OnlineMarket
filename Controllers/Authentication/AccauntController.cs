using Microsoft.EntityFrameworkCore;

public class AccountController : ControllerBase
{
    private readonly IUserService accaunt;

    public AccountController(IUserService accaunt)
    {
        this.accaunt = accaunt;
    }

    [HttpPost]
    [Route("api/register")]
    public async Task<Responce<UserCreateDto>> RegisterAsync(UserCreateDto userdto)
    {
        var register = await accaunt.RegisterAsync(userdto);

        return register;
    }

    [HttpPost]
    [Route("api/login")]
    public async Task<Responce<UserCreateDto>> LoginAsync(UserCreateDto user)
    {
        var login = await accaunt.LoginAsync(user);

        return login;
    }
}
