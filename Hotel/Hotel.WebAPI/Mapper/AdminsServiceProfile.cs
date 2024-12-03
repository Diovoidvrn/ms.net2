using AutoMapper;
using Hotel.BL.Admin.Entities;
using Hotel.WebAPI.Controllers.Entities;

namespace Hotel.WebAPI.Mapper
{
    public class AdminsServiceProfile : Profile
    {
        public AdminsServiceProfile() 
        {
            CreateMap<AdminsFilter, AdminModelFilter>();
            CreateMap<CreateAdminRequest, CreateAdminModel>();
            CreateMap<UpdateAdminRequest, UpdateAdminModel>();
        }
    }
}
