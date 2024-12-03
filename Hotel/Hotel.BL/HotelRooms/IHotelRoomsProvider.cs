
using Hotel.BL.HotelRooms.Entities;

namespace Hotel.BL.HotelRooms
{
    public interface IHotelRoomsProvider
    {
        IEnumerable<HotelRoomModel> GetHotelRooms(HotelRoomModelFilter modelFilter = null);
        HotelRoomModel GetHotelRoomInfo(Guid id);
    }
}
