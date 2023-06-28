namespace OnlineBookstore.Repositories
{
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public void Edit(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsersByCity(string city)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsersByCountry(string country)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsersByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
