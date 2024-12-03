using AutoMapper;
using Hotel.BL.User.Entities;
using Hotel.DataAccess.Entities;

namespace Hotel.BL.Mapper
{
    public class UserBLProfile : Profile
    {
        public UserBLProfile()
        {
            CreateMap<UserEntity, UserModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

            CreateMap<CreateUserModel, UserEntity>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore())
                .ForMember(x => x.Reviews, y => y.Ignore())
                .ForMember(x => x.Reservations, y => y.Ignore());
        }
    }
}
