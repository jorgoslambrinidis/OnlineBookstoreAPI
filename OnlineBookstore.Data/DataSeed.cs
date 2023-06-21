namespace OnlineBookstore.Data
{
    using Microsoft.EntityFrameworkCore;
    using OnlineBookstore.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class DataSeed
    {

        #region Seed Method

        public static void Seed(ModelBuilder builder, string username, byte[] passwordHash, byte[] passwordSalt)
        {
            #region User Admin Seed
            builder.Entity<User>().HasData(
            new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                Email = "smx.test@smx.com",
                City = "Skopje",
                Country = "Macedonia",
                Address = "/",
                UserCreated = DateTime.Now,
                Description = "*** Admin User ***",
                Phone = "223305",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsAdmin = true,
            });
            #endregion

        }

        #endregion
    }
}
