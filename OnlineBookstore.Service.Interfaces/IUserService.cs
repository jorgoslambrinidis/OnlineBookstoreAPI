namespace OnlineBookstore.Service.Interfaces
{
    using OnlineBookstore.Entities;
    using System.Collections.Generic;

    public interface IUserService
    {
        void Add(User user);

        void Edit(User user);

        void Delete(User user);

        User GetUserById(string id);

        User GetUserByUsername(string username);

        IEnumerable<User> GetUsersByCountry(string country);

        IEnumerable<User> GetUsersByCity(string city);

        IEnumerable<User> GetUsersByEmail(string email);

        IEnumerable<User> GetAllUsers();
    }
}
