using System.ComponentModel.DataAnnotations.Schema;


namespace Hotel.DataAccess.Entities
{
    [Table("reservations")]
    public class ReservationEntity : BaseEntity
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int HotelRoomId { get; set; }
        public HotelRoomEntity HotelRoom { get; set; }

    }
}
