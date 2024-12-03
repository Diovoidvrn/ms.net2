using Hotel.BL.User.Entities;

namespace Hotel.WebAPI.Controllers.Entities
{
    public class UsersListResponse
    {
        public List<UserModel> Users { get; set; }
    }
}
