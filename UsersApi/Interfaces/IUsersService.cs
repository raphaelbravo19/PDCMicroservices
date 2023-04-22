using CorePDC.Common;
using UsersApi.Interfaces.Requests;

namespace UsersApi.Interfaces
{
    public interface IUserService
    {
        SimpleItemListResponse<User> GetUsers();
        SingleItemResponse<User> GetUser(int userId);
        SingleItemResponse<User> CreateUser(DtoUser dtoUser);
    }
}
