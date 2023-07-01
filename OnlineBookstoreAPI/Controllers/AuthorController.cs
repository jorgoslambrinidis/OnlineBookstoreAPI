namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class AuthorController : BaseApiController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("Authors")]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            var authors = _authorService.GetAuthors();
            return Ok(authors);
        }
    }
}
