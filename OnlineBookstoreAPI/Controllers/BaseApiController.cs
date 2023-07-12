namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController<T> : ControllerBase where T : BaseApiController<T>
    {
        private ILogger<T> _logger = null!;
        protected ILogger<T> Logger => _logger ?? (_logger = HttpContext.RequestServices.GetService<ILogger<T>>()!);
    }
}
