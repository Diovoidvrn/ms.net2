using Hotel.BL.HotelRooms.Entities;

namespace Hotel.WebAPI.Controllers.Entities
{
    public class HotelRoomsListResponse
    {
        public List<HotelRoomModel> HotelRooms { get; set; }
    }
}
