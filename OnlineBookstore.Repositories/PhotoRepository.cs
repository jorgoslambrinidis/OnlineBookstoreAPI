namespace OnlineBookstore.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using OnlineBookstore.Data;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PhotoRepository : IPhotoRepository
    {
        private readonly OnlineBookstoreDbContext _context;

        public PhotoRepository(OnlineBookstoreDbContext context)
        {
            _context = context;
        }

        public void Add(Photo photo)
        {
            throw new NotImplementedException();
        }

        public void Delete(Photo photo)
        {
            throw new NotImplementedException();
        }

        public void Edit(Photo photo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetAllMainPhotos(bool isMain)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetAllPhotos()
        {
            var result = _context.Photos.AsEnumerable();
            return result;
        }

        public Photo GetPhotoById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetPhotosByDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
