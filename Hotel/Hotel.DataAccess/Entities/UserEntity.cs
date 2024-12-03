using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hotel.DataAccess.Entities
{
    [Table("users")]
    public class UserEntity : IdentityUser<int>, IBaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<ReviewEntity> Reviews { get; set; }
        public virtual ICollection<ReservationEntity> Reservations { get; set; }

        public Guid ExternalId { get; set; }
        public DateTime ModificationTime { get; set; }
        public DateTime CreationTime { get; set; }
    }

    public class UserRoleEntity : IdentityRole<int>
    {
    }
}
