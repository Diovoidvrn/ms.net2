using AutoMapper;
using Hotel.DataAccess.Entities;
using Hotel.DataAccess;
using Hotel.BL.User.Entities;

namespace Hotel.BL.User
{
    public class UsersManager : IUsersManager
    {
        private readonly IRepository<UserEntity> _usersRepository;
        private readonly IMapper _mapper;

        public UsersManager(IRepository<UserEntity> usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public UserModel CreateUser(CreateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);

            _usersRepository.Save(entity);

            return _mapper.Map<UserModel>(entity);
        }

        public void DeleteUser(Guid id)
        {
            var entity = _usersRepository.GetById(id);

            if (entity == null)
                throw new ArgumentException("User not found");

            _usersRepository.Delete(entity);
        }

        public UserModel UpdateUser(Guid id, UpdateUserModel model)
        {
            var entity = _usersRepository.GetById(id);

            if (entity == null)
                throw new ArgumentException("User not found");

            entity.Name = model.Name;
            entity.Surname = model.Surname;
            entity.Patronymic = model.Patronymic;
            entity.Birthday = model.Birthday;
            entity.PhoneNumber = model.PhoneNumber;
            entity.Email = model.Email;
            entity.ImageUrl = model.ImageUrl;
            entity.PasswordHash = model.PasswordHash;

            _usersRepository.Save(entity);

            return _mapper.Map<UserModel>(entity);
        }
    }
}
