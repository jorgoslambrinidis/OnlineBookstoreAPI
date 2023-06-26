namespace OnlineBookstore.Repository.Interfaces
{
    using OnlineBookstore.Entities;
    using System.Collections.Generic;

    public interface IPhotoRepository
    {
        void Add(Photo photo);

        void Edit(Photo photo);

        void Delete(Photo photo);

        Photo GetPhotoById(int id);

        IEnumerable<Photo> GetAllPhotos();

        IEnumerable<Photo> GetPhotosByDate(DateTime date);

        IEnumerable<Photo> GetAllMainPhotos(bool isMain);
    }
}
