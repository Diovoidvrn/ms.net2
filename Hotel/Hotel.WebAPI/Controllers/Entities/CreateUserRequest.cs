using System.ComponentModel.DataAnnotations;

namespace Hotel.WebAPI.Controllers.Entities
{
    public class CreateUserRequest
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
        public DateTime Birthday { get; set; }

        [Required]
        [MinLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MinLength(2)]
        public string PasswordHash { get; set; }
    }
}
