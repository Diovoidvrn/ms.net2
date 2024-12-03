using System.ComponentModel.DataAnnotations.Schema;


namespace Hotel.DataAccess.Entities
{
    [Table("admins")]
    public class AdminEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
