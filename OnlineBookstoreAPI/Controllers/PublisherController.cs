namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class PublisherController : BaseApiController
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
    }
}
