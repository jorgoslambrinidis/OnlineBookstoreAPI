namespace OnlineBookstore.Repository.Interfaces
{
    using OnlineBookstore.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        void Add(User user);

        void Edit(User user);

        void Delete(User user);

        User GetUserById(string id);

        User GetUserByUsername(string username);
        
        User GetUserByEmail(string email);

        IEnumerable<User> GetUsersByCountry(string country);

        IEnumerable<User> GetUsersByCity(string city);

        IEnumerable<User> GetAllUsers();
    }
}
