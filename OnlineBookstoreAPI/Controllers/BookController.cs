namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;
    using OnlineBookstoreAPI.Helpers;

    public class BookController : BaseApiController
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(
            IBookService bookService,
            ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet("Books")]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            try
            {
                var books = _bookService.GetAllBooks();

                if (books == null)
                {
                    //return NotFound();
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                else
                {
                    _logger.LogInformation(InfoMessages.AllBooksTakenFromDb);
                    return Ok(books);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetrievingData);
            }
        }

        [HttpGet("Book")]
        public ActionResult<Book> GetBook(int id)
        {
            try
            {
                var book = _bookService.GetBookById(id);

                if (book == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, InfoMessages.BookNotFound);
                }
                else
                {
                    _logger.LogInformation("A book is taken from the db.");
                    //return Ok(book);
                    return StatusCode(StatusCodes.Status200OK, book);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetrievingData);
            }
        }

        [HttpPost("Add")]
        public ActionResult<Book> AddBook(Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest();
                    //return StatusCode(StatusCodes.Status400BadRequest, "Ovde da vratime nekoja poraka");
                }

                _bookService.Add(book);

                return CreatedAtAction(nameof(AddBook), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetrievingData);
            }
        }

        [HttpPost("Edit")]
        public ActionResult EditBook(Book book)
        {
            try
            {
                var bookToEdit = _bookService.GetBookById(book.Id);

                if (bookToEdit == null)
                {
                    return NotFound($"Book with Id = {book.Id} not found!");
                    //return StatusCode(StatusCodes.Status404NotFound, "nekoj message za not found");
                }

                _bookService.Edit(book);

                return StatusCode(StatusCodes.Status202Accepted, book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetrievingData);
            }
        }

        [HttpDelete("Delete")]
        public ActionResult<Book> DeleteBook(int id)
        {
            try
            {
                var getBookById = _bookService.GetBookById(id);

                if (getBookById == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                _bookService.Delete(getBookById);
                _logger.LogInformation($"A book with id: {getBookById.Id} is deleted from the db.");

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetrievingData);
            }
        }
    }
}
