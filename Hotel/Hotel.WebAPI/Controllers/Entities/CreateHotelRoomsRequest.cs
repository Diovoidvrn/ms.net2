using System.ComponentModel.DataAnnotations;

namespace Hotel.WebAPI.Controllers.Entities
{
    public class CreateHotelRoomsRequest
    {
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1,5)]
        public int NumberOfGuests { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int HotelId { get; set; }
    }
}
