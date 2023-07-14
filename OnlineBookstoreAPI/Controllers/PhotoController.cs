namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class PhotoController : BaseApiController<PhotoController>
    {
        private readonly IPhotoService _photoService;
        private readonly IBaseService<Photo> _baseService;

        public PhotoController(
            IPhotoService photoService,
            IBaseService<Photo> baseService
        )
        {
            _photoService = photoService;
            _baseService = baseService;
        }

        [HttpGet("Photos")]
        public ActionResult<IEnumerable<Photo>> GetAllPhotos()
        {
            try
            {
                var photos = _photoService.GetAllPhotos();
                //var photos = _baseService.GetAll();

                if (photos == null)
                {
                    //return StatusCode(StatusCodes.Status404NotFound, "The list is empty");
                    return NotFound();
                }
                else
                {
                    Logger.LogInformation("All photos all taken from th db.");
                    return Ok(photos);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetievingDataFromDB);
            }
        }
    }
}
