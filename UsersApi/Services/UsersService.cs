using CorePDC.Common;
using UsersApi.Interfaces;
using UsersApi.Interfaces.Requests;

namespace UsersApi.Services
{
    public class UserService : IUserService
    {
        private readonly IAlblasaContext _alblasaContext;
        private readonly ILogger _logger;

        public UserService(IAlblasaContext alblasaContext, ILogger<IUserService> logger)
        {
            _alblasaContext = alblasaContext;
            _logger = logger;
        }

        public SimpleItemListResponse<User> GetUsers()
        {
            try
            {
                var users = _alblasaContext.Users.ToList();

                return new SimpleItemListResponse<User>
                {
                    ErrorCode = "200",
                    ErrorMessage = "The users have been succesfully retrieved",
                    Items = users
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new SimpleItemListResponse<User>
                {
                    ErrorCode = "500",
                    ErrorMessage = ex.Message
                };
            }
        }

        public SingleItemResponse<User> GetUser(int userId)
        {
            try
            {
                var user = _alblasaContext.Users.Find(userId);

                if (user == null)
                {
                    return new SingleItemResponse<User>
                    {
                        ErrorCode = "204",
                        ErrorMessage = "The usedId is invalid"
                    };
                }

                return new SingleItemResponse<User>
                {
                    ErrorCode = "200",
                    ErrorMessage = "The user has been succesfully retrieved",
                    Item = user
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new SingleItemResponse<User>
                {
                    ErrorCode = "500",
                    ErrorMessage = ex.Message
                };
            }
        }

        public SingleItemResponse<User> CreateUser(DtoUser dtoUser)
        {
            try
            {
                var user = new User
                {
                    Name = dtoUser.Name,
                    LastName = dtoUser.LastName,
                    Age = dtoUser.Age
                };

                _alblasaContext.Users.Add(user);
                _alblasaContext.SaveChanges();

                return new SingleItemResponse<User>
                {
                    ErrorCode = "200",
                    ErrorMessage = "The user has been succesfully created",
                    Item = user
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new SingleItemResponse<User>
                {
                    ErrorCode = "500",
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
