
using Hotel.BL.HotelRooms.Entities;

namespace Hotel.BL.HotelRooms
{
    public interface IHotelRoomsManager
    {
        HotelRoomModel CreateHotelRoom(CreateHotelRoomModel model);
        void DeleteHotelRoom(Guid id);
        HotelRoomModel UpdateHotelRoom(Guid id, UpdateHotelRoomModel model);
    }
}
