using System.ComponentModel.DataAnnotations.Schema;


namespace Hotel.DataAccess.Entities
{
    [Table("photos")]
    public class PhotoEntity : BaseEntity
    {
        public string ImageUrl { get; set; }

        public int? HotelId { get; set; }
        public HotelEntity? Hotel { get; set; }
        public int? HotelRoomId { get; set; }
        public HotelRoomEntity? HotelRoom { get; set; }

    }
}
