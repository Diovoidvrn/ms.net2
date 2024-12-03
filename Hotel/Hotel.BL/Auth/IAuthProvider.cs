using Hotel.BL.Auth.Entities;

namespace Hotel.BL.Auth
{
    public interface IAuthProvider
    {
        Task<TokensResponse> AuthorizeUser(string email, string password);
        Task RegisterUser(string surname, string name, string patronymic, DateTime birthday,
            string phoneNumber, string imageUrl, string email, string password);
    }
}
