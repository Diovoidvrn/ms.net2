using Hotel.BL.User.Entities;

namespace Hotel.BL.User
{
    public interface IUsersProvider
    {
        IEnumerable<UserModel> GetUsers(UserModelFilter modelFilter = null);
        UserModel GetUserInfo(Guid id);
    }
}
