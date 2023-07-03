namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class PhotoController : BaseApiController
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpGet("Photos")]
        public ActionResult<IEnumerable<Photo>> GetAllPhotos()
        {
            var photos = _photoService.GetAllPhotos();
            return Ok(photos);
        }
    }
}
