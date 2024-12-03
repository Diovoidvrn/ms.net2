using AutoMapper;
using Hotel.BL.Auth.Entities;
using Hotel.BL.User.Entities;
using Hotel.WebAPI.Controllers.Entities;

namespace Hotel.WebAPI.Mapper
{
    public class UsersServiceProfile : Profile
    {
        public UsersServiceProfile() 
        {
            CreateMap<UsersFilter, UserModelFilter>();
            CreateMap<CreateUserRequest, CreateUserModel>();
            CreateMap<UpdateUserRequest, UpdateUserModel>();
        }
    }
}
