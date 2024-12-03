using System.ComponentModel.DataAnnotations;


namespace Hotel.WebAPI.Controllers.Entities
{
    public class CreateAdminRequest
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        public string Surname { get; set; }

        [Required]
        [MinLength(2)]
        public string Patronymic { get; set; }

        [Required]
        [MinLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(10)]
        public string PasswordHash { get; set; }
    }
}
