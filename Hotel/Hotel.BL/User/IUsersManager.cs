using Hotel.BL.User.Entities;

namespace Hotel.BL.User
{
    public interface IUsersManager
    {
        UserModel CreateUser(CreateUserModel model);
        void DeleteUser(Guid id);
        UserModel UpdateUser(Guid id, UpdateUserModel model);
    }
}
