using AutoMapper;
using Hotel.BL.HotelRooms.Entities;
using Hotel.DataAccess.Entities;

namespace Hotel.BL.Mapper
{
    public class HotelRoomBLProfile : Profile
    {
        public HotelRoomBLProfile() 
        {
            CreateMap<HotelRoomEntity, HotelRoomModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

            CreateMap<CreateHotelRoomModel, HotelRoomEntity>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore())
                .ForMember(x => x.Photos, y => y.Ignore())
                .ForMember(x => x.Hotel, y => y.Ignore())
                .ForMember(x => x.Reservations, y => y.Ignore());
        }
    }
}
