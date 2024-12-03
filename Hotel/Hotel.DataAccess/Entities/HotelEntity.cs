using System.ComponentModel.DataAnnotations.Schema;


namespace Hotel.DataAccess.Entities
{
    [Table("hotels")]
    public class HotelEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Info { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<PhotoEntity> Photos { get; set; }
        public virtual ICollection<HotelRoomEntity> HotelRooms { get; set;}
        public virtual ICollection<ReviewEntity> Reviews { get; set; }
    }
}
