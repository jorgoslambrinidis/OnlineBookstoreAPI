namespace OnlineBookstore.Repositories
{
    using OnlineBookstore.Data;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PhotoRepository : IPhotoRepository
    {
        private readonly OnlineBookstoreDbContext _context;

        public PhotoRepository(OnlineBookstoreDbContext context)
        {
            _context = context;
        }

        public void Add(Photo photo)
        {
            _context.Photos.Add(photo);
            _context.SaveChanges();
        }

        public void Delete(Photo photo)
        {
            _context.Photos.Remove(photo);
            _context.SaveChanges();
        }

        public void Edit(Photo photo)
        {
            _context.Photos.Update(photo);
            _context.SaveChanges();
        }

        public IEnumerable<Photo> GetAllMainPhotos(bool isMain)
        {
            var result = _context.Photos.Where(p => p.IsMain == isMain).AsEnumerable();
            return result;
        }

        public IEnumerable<Photo> GetAllPhotos()
        {
            var result = _context.Photos.AsEnumerable();
            return result;
        }

        public Photo GetPhotoById(int id)
        {
            var result = _context.Photos.FirstOrDefault(p => p.Id == id);
            return result;
        }

        public IEnumerable<Photo> GetPhotosByDate(DateTime date)
        {
            var result = _context.Photos.Where(p => p.DateAdded == date).AsEnumerable();
            return result;
        }
    }
}
