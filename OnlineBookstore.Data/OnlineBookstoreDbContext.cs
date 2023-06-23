namespace OnlineBookstore.Data
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Entities.Config;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    public class OnlineBookstoreDbContext : DbContext
    {
        public OnlineBookstoreDbContext(DbContextOptions options) : base(options)
        {

        }

        // here construct the DB tables from entities classes
        // ---------------------------------------------------

        public DbSet<User> Users { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
        //public DbSet<NovaTabela> NovaTabelaa { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            byte[] passwordHash, passwordSalt;

            // uncomment for testing purposes
            // Debugger.Launch();

            var currentDirectory = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentDirectory, "Settings", "user_settings.json");

            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(File.ReadAllText(filePath));

            CreatePasswords(userSettings.AdminCredentials.Password, out passwordHash, out passwordSalt);

            DataSeed.Seed(builder, userSettings.AdminCredentials.Username, passwordHash, passwordSalt);
            base.OnModelCreating(builder);
        }

        #region Helper Methods

        private void CreatePasswords(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        #endregion
    }
}
