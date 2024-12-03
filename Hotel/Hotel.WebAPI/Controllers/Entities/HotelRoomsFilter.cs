namespace Hotel.WebAPI.Controllers.Entities
{
    public class HotelRoomsFilter
    {
        public int? NumberOfGuests { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
    }
}
