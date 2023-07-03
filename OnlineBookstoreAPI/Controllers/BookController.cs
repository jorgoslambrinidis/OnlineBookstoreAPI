namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class BookController : BaseApiController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("Books")]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }
    }
}
