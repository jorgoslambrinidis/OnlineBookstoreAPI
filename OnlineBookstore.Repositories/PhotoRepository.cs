namespace OnlineBookstore.Repositories
{
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PhotoRepository : IPhotoRepository
    {
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
            throw new NotImplementedException();
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
