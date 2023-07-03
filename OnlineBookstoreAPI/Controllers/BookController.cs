namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;
    using OnlineBookstoreAPI.Helpers;

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
            try
            {
                var books = _bookService.GetAllBooks();

                if (books == null)
                {
                    //return NotFound();
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return Ok(books);
            }
            catch (Exception ex)
            {
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
                    //return Ok(book);
                    return StatusCode(StatusCodes.Status200OK, book);
                }
            }
            catch (Exception ex)
            {
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

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetrievingData);
            }
        }
    }
}
