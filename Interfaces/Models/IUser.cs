public interface IUserService
{
    public Task<Responce<UserCreateDto>> RegisterAsync(UserCreateDto userdto);
    public Task<Responce<UserCreateDto>> LoginAsync(UserCreateDto user);
}