namespace OnlineBookstore.Repositories
{
    using Microsoft.Extensions.Logging;
    using OnlineBookstore.Data;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserRepository : IUserRepository
    {
        private readonly OnlineBookstoreDbContext _context;
        private readonly ILogger<BookRepository> _logger;

        public UserRepository(OnlineBookstoreDbContext context, ILogger<BookRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.UserCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageDisplay.UserNotCreatedModelStateInvalid, ex);
            }
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Edit(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var result = _context.Users.AsEnumerable();
            return result;
        }

        public User GetUserById(string id)
        {
            var result = _context.Users.FirstOrDefault(b => b.Id.ToString() == id);
            return result;
        }

        public User GetUserByUsername(string username)
        {
            var result = _context.Users.FirstOrDefault(b => b.Username == username);
            return result;
        }

        public IEnumerable<User> GetUsersByCity(string city)
        {
            var result = _context.Users.Where(b => b.City == city).AsEnumerable();
            return result;
        }

        public IEnumerable<User> GetUsersByCountry(string country)
        {
            var result = _context.Users.Where(b => b.Country == country).AsEnumerable();
            return result;
        }

        public User GetUserByEmail(string email)
        {
            var result = _context.Users.FirstOrDefault(b => b.Email == email);
            return result;
        }
    }
}
