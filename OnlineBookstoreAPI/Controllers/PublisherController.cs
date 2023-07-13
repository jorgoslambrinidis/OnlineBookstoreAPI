namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class PublisherController : BaseApiController<OrderController>
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet("Publishers")]
        public ActionResult<IEnumerable<Publisher>> GetAllPublishers()
        {
            var publishers = _publisherService.GetAllPublishers();
            return Ok(publishers);
        }

        [HttpGet("Publisher")]
        public ActionResult<Publisher> GetPublisher(int id)
        {
            try
            {
                var publisher = _publisherService.GetPublisherById(id);

                if (publisher == null)
                {
                    Logger.LogInformation(message: new GenerateDynamicMessage().GenerateNotFoundMessage("Publisher"));
                    return NotFound();
                }
                else
                {
                    return Ok(publisher);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetievingDataFromDB);
            }
        }

        [HttpPut("Edit")]
        public IActionResult EditPublisher(Publisher publisher)
        {
            try
            {
                var publisherToEdit = _publisherService.GetPublisherById(publisher.Id);

                if (publisherToEdit == null)
                {
                    Logger.LogInformation(message: new GenerateDynamicMessage().GenerateNotFoundMessage("Publisher"));
                    return NotFound($"Publisher with Id = {publisher.Id} not found!");
                }

                _publisherService.Edit(publisher);

                return StatusCode(StatusCodes.Status202Accepted, publisher);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorUpdatingData);
            }
        }

        [HttpPost("Add")]
        public ActionResult<Publisher> AddPublisher(Publisher publisher)
        {
            try
            {
                if (publisher == null)
                {
                    return BadRequest();
                }

                _publisherService.Add(publisher);

                return CreatedAtAction(nameof(AddPublisher), new { id = publisher.Id }, publisher);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new publisher record!");
            }
        }

        [HttpDelete("Delete")]
        public ActionResult<Publisher> DeletePublisher(int id)
        {
            try
            {
                var publisher = _publisherService.GetPublisherById(id);

                if (publisher == null)
                {
                    return NotFound($"Publisher with Id = {id} not found!");
                }

                _publisherService.Delete(publisher);

                return NoContent();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorDeletingData);
            }
        }

    }
}
