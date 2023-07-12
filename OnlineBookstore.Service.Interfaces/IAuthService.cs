namespace OnlineBookstore.Service.Interfaces
{
    using OnlineBookstore.Entities;
    using System.Threading.Tasks;

    public interface IAuthService
    {
        Task<User> Login(string username, string password);

        Task<User> Register(User user, string password);

        Task<bool> UserExists(string email);
    }
}
