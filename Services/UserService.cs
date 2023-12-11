using Microsoft.EntityFrameworkCore;
using OnlineMarket.Models.User;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(OnlineMarketDB context)
    {
        this._unitOfWork = new UnitOfWork(context);

        this._mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile<MapperProfile>()
            ));
    }

    public async Task<Responce<UserCreateDto>> RegisterAsync(UserCreateDto userdto)
    {
        try
        {

            var usercreate = new User()
            {
                Username = userdto.Username,
                Password = userdto.Password,
            };

            await _unitOfWork.UserRepository.AddAsync(usercreate);
            await _unitOfWork.UserRepository.SaveAsync();

            return new Responce<UserCreateDto>
            {
                StatusCode = 200,
                Message = "Mahsulot muvaffaqiyatli yaratildi",
                Data = null
            };

        }
        catch (Exception ex)
        {
            return new Responce<UserCreateDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }


        
    }

    public async Task<Responce<UserCreateDto>> LoginAsync(UserCreateDto user)
    {
        try
        {
            // Implement login logic
            var existingUser = await _unitOfWork.UserRepository
                .FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);

            if (existingUser != null)
            {
                return new Responce<UserCreateDto>
                {
                    StatusCode = 200,
                    Message = "Login successful",
                    Data = null
                };
            }
            else
            {
                return new Responce<UserCreateDto>
                {
                    StatusCode = 400,
                    Message = "Invalid username or password",
                    Data = null
                };
            }
        }
        catch (Exception ex)
        {
            return new Responce<UserCreateDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    }
}
