namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class PhotoController : BaseApiController<PhotoController>
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpGet("Photos")]
        public ActionResult<IEnumerable<Photo>> GetAllPhotos()
        {
            try
            {
                var photos = _photoService.GetAllPhotos();

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
