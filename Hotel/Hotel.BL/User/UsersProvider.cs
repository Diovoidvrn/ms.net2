
using AutoMapper;
using Hotel.DataAccess.Entities;
using Hotel.DataAccess;
using Hotel.BL.User.Entities;

namespace Hotel.BL.User
{
    public class UsersProvider : IUsersProvider
    {
        private readonly IRepository<UserEntity> _usersRepository;
        private readonly IMapper _mapper;

        public UsersProvider(IRepository<UserEntity> usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public UserModel GetUserInfo(Guid id)
        {
            var user = _usersRepository.GetById(id);
            if (user is null)
                throw new ArgumentException("User not found.");

            return _mapper.Map<UserModel>(user);
        }

        public IEnumerable<UserModel> GetUsers(UserModelFilter modelFilter = null)
        {
            var surname = modelFilter?.Surname;
            var name = modelFilter?.Name;
            var birthday = modelFilter?.Birthday;
            var phoneNumber = modelFilter?.PhoneNumber;
            var email = modelFilter?.Email;

            var users = _usersRepository.GetAll(x => (
                surname == null || surname == x.Surname ||
                name == null || name == x.Name ||
                birthday == null || birthday == x.Birthday ||
                phoneNumber == null || phoneNumber == x.PhoneNumber ||
                email == null || email == x.Email));

            return _mapper.Map<IEnumerable<UserModel>>(users);
        }
    }
}
