namespace OnlineBookstore.Service.Interfaces
{
    using OnlineBookstore.Entities;

    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
