namespace Hotel.WebAPI.Controllers.Entities
{
    public class UpdateHotelRoomRequest
    {
        public string Description { get; set; }
        public int NumberOfGuests { get; set; }
        public int Price { get; set; }
    }
}
