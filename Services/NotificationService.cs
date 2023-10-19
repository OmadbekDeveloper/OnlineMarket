public class NotificationService : INotificationService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public NotificationService(OnlineMarketDB context)
    {
        this._unitOfWork = new UnitOfWork(context);

        this._mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile<MapperProfile>()
            ));
    }

    public async Task<Responce<IEnumerable<ResultNotificationDto>>> GetAllNotificationsAsync()
    {
        try
        {
            var getAll = await _unitOfWork.NotificationRepository.GetAllAsync();

            if (getAll == null)
            {
                return new Responce<IEnumerable<ResultNotificationDto>>
                {
                    StatusCode = 404,
                    Message = "Not found",
                    Data = null
                };
            }

            var mapper = _mapper.Map<IEnumerable<ResultNotificationDto>>(getAll);

            return new Responce<IEnumerable<ResultNotificationDto>>
            {
                StatusCode = 200,
                Message = "All products received",
                Data = mapper
            };
        }
        catch (Exception ex)
        {
            return new Responce<IEnumerable<ResultNotificationDto>>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<ResultNotificationDto>> GetNotificationByIdAsync(int id)
    {
        try
        {
            var getById = _unitOfWork.NotificationRepository.Get(x => x.NotificationId == id);

            if (getById == null)
            {
                return new Responce<ResultNotificationDto>
                {
                    StatusCode = 404,
                    Message = "Not Found",

                };
            }

            var map = _mapper.Map<ResultNotificationDto>(getById);

            return new Responce<ResultNotificationDto>
            {
                StatusCode = 200,
                Message = "all taken out",
                Data = map,
            };
        }
        catch (Exception ex)
        {
            return new Responce<ResultNotificationDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }

    } // done

    public async Task<Responce<ResultNotificationDto>> CreateNotificationAsync(CreateNotificationDto notificationdto)
    {
        try
        {
            var create = new Notification()
            {
                NotificationId = notificationdto.NotificationId,
                UserId = notificationdto.UserId,
                Message = notificationdto.Message,
            };

            _unitOfWork.NotificationRepository.Add(create);
            await _unitOfWork.NotificationRepository.SaveAsync();

            return new Responce<ResultNotificationDto>
            {
                StatusCode = 200,
                Message = "Mahsulot muvaffaqiyatli yaratildi",
                Data = null,
            };
        }
        catch (Exception ex)
        {
            return new Responce<ResultNotificationDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null,
            };
        }
    } // done

    public async Task<Responce<IEnumerable<ResultNotificationDto>>> UpdateNotificationAsync(UpdateNotificationDto updatedto)
    {
        try
        {
            var update = _unitOfWork.NotificationRepository.Get(x => x.NotificationId == updatedto.NotificationId);

            if (update == null)
            {
                return new Responce<IEnumerable<ResultNotificationDto>>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                };
            }

            var map = _mapper.Map(updatedto, update);

            _unitOfWork.NotificationRepository.Update(map);
            await _unitOfWork.NotificationRepository.SaveAsync();

            return new Responce<IEnumerable<ResultNotificationDto>>
            {
                StatusCode = 200,
                Message = "Mahsulot yangilandi",
                Data = null
            };
        }
        catch (Exception ex)
        {
            return new Responce<IEnumerable<ResultNotificationDto>>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    }

    public async Task<Responce<bool>> DeleteNotificationAsync(int id)
    {
        try
        {
            var delete = _unitOfWork.NotificationRepository.Get(x => x.NotificationId == id);

            if (delete == null)
            {
                return new Responce<bool>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Data = false
                };
            }

            _unitOfWork.NotificationRepository.Remove(delete);
            await _unitOfWork.NotificationRepository.SaveAsync();

            return new Responce<bool>
            {
                StatusCode = 200,
                Message = "Product deleted successfully",
                Data = true
            };
        }
        catch (Exception ex)
        {
            return new Responce<bool>
            {
                StatusCode = 500,
                Message = "Error",
                Data = false
            };
        }
    }
}
