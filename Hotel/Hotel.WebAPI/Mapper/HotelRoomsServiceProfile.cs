using AutoMapper;
using Hotel.BL.Admin.Entities;
using Hotel.BL.HotelRooms.Entities;
using Hotel.WebAPI.Controllers.Entities;

namespace Hotel.WebAPI.Mapper
{
    public class HotelRoomsServiceProfile : Profile
    {
        public HotelRoomsServiceProfile()
        {
            CreateMap<HotelRoomsFilter, HotelRoomModelFilter>();
            CreateMap<CreateHotelRoomsRequest, CreateHotelRoomModel>();
            CreateMap<UpdateHotelRoomRequest, UpdateHotelRoomModel>();
        }
    }
}
