namespace Hotel.WebAPI.Controllers.Entities
{
    public class UsersFilter
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Birthday { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
