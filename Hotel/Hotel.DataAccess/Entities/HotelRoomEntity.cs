using System.ComponentModel.DataAnnotations.Schema;


namespace Hotel.DataAccess.Entities
{
    [Table("hotelRooms")]
    public class HotelRoomEntity : BaseEntity
    {
        public string Description { get; set; }
        public int NumberOfGuests { get; set; }
        public int Price { get; set; }

        public int HotelId { get; set; }
        public HotelEntity Hotel { get; set; }
        public virtual ICollection<PhotoEntity> Photos { get; set; } 
        public virtual ICollection<ReservationEntity> Reservations { get; set; }

    }
}
