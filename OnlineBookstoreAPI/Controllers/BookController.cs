namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class BookController : BaseApiController<BookController>
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
                    Logger.LogInformation(message: new GenerateDynamicMessage().GenerateNotFoundMessage("Book"));
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
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetievingDataFromDB);
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
                    Logger.LogInformation(message: new GenerateDynamicMessage().GenerateNotFoundMessage("Book"));
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
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetievingDataFromDB);
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
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetievingDataFromDB);
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
                    Logger.LogInformation(message: new GenerateDynamicMessage().GenerateNotFoundMessage($"Book with Id = {book.Id}"));
                    return NotFound($"Book with Id = {book.Id} not found!");
                    //return StatusCode(StatusCodes.Status404NotFound, "nekoj message za not found");
                }

                _bookService.Edit(book);

                return StatusCode(StatusCodes.Status202Accepted, book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetievingDataFromDB);
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
                    Logger.LogInformation(message: new GenerateDynamicMessage().GenerateNotFoundMessage($"A book with id: {getBookById.Id}"));
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                _bookService.Delete(getBookById);
                _logger.LogInformation($"A book with id: {getBookById.Id} is deleted from the db.");

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetievingDataFromDB);
            }
        }

        [HttpGet("GetAllBooksWithRelationalData")]
        public ActionResult<IEnumerable<Book>> GetAllBooksWithFullRelationalData()
        {
            try
            {
                var booksWithFullData = _bookService.GetAllBooksWithFullRelationalData();

                if (booksWithFullData == null)
                {
                    Logger.LogInformation(message: new GenerateDynamicMessage().GenerateNotFoundMessage("Books with full data"));
                    return NotFound();
                }
                else
                    return Ok(booksWithFullData);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetievingDataFromDB);
            }
        }


    }
}
