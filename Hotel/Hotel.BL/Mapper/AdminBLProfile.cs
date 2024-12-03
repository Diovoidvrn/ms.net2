using AutoMapper;
using Hotel.BL.Admin.Entities;
using Hotel.DataAccess.Entities;

namespace Hotel.BL.Mapper
{
    public class AdminBLProfile : Profile
    {
        public AdminBLProfile()
        {
            CreateMap<AdminEntity, AdminModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

            CreateMap<CreateAdminModel, AdminEntity>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore());
        }
    }
}
