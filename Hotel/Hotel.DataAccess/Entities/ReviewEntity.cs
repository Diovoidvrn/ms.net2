using System.ComponentModel.DataAnnotations.Schema;


namespace Hotel.DataAccess.Entities
{
    [Table("reviews")]
    public class ReviewEntity : BaseEntity
    {
        public string Review { get; set; }

        public int HotelId { get; set; }
        public HotelEntity Hotel { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }

    }
}
