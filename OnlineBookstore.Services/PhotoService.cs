namespace OnlineBookstore.Services
{
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using OnlineBookstore.Service.Interfaces;
    using System;
    using System.Collections.Generic;

    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        //private readonly IPhotoRepository _photoRepository;
        //private readonly IUserRepository _userRepository;

        //public PhotoService(IPhotoRepository photoRepository, IUserRepository userRepository)
        //{
        //    _photoRepository = photoRepository;
        //    _userRepository = userRepository;
        //}

        public void Add(Photo photo)
        {
            _photoRepository.Add(photo);
        }

        public void Delete(Photo photo)
        {
            _photoRepository.Delete(photo);
        }

        public void Edit(Photo photo)
        {
            _photoRepository.Edit(photo);
        }

        public IEnumerable<Photo> GetAllMainPhotos(bool isMain)
        {
            var result = _photoRepository.GetAllMainPhotos(isMain);
            return result;
        }

        public IEnumerable<Photo> GetAllPhotos()
        {
            var result = _photoRepository.GetAllPhotos();
            return result;
        }

        public Photo GetPhotoById(int id)
        {
            var result = _photoRepository.GetPhotoById(id);
            return result;
        }

        public IEnumerable<Photo> GetPhotosByDate(DateTime date)
        {
            var result = _photoRepository.GetPhotosByDate(date);
            return result;
        }
    }
}
