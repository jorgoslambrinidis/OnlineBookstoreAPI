namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class AuthorController : BaseApiController<AuthorController>
    {
        private readonly IAuthorService _authorService;
        private readonly IBaseService<Author> _baseService;

        public AuthorController(
            IAuthorService authorService,
            IBaseService<Author> baseService
        )
        {
            _authorService = authorService;
            _baseService = baseService;
        }

        [HttpGet("Authors")]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            try
            {
                var authors = _authorService.GetAuthors();
                //var authors = _baseService.GetAll();

                if (authors == null)
                {
                    return NotFound();
                }
                else
                {
                    Logger.LogInformation("All authors all taken from th db.");
                    return Ok(authors);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetievingDataFromDB);
            }
        }


        [HttpGet("Author")]
        public ActionResult<Author> GetAuthor(int id)
        {
            try
            {
                var author = _authorService.GetAuthorById(id);
                //var author = _baseService.Get(id);

                if (author == null)
                {
                    Logger.LogInformation(message: new GenerateDynamicMessage().GenerateNotFoundMessage("Author"));
                    return NotFound();
                }
                else
                {
                    return Ok(author);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetievingDataFromDB);
            }
        }

        [HttpPost("Edit")]
        public IActionResult EditAuthor(Author author)
        {
            try
            {
                var authorToEdit = _authorService.GetAuthorById(author.Id);
                //var authorToEdit = _baseService.Get(author.Id);

                if (authorToEdit == null)
                {
                    Logger.LogInformation(message: new GenerateDynamicMessage().GenerateNotFoundMessage($"Author with Id = {author.Id}"));
                    return NotFound($"Author with Id = {author.Id} not found!");
                }

                //_baseService.Edit(author);
                _authorService.Edit(author);

                return StatusCode(StatusCodes.Status202Accepted, author);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorUpdatingData);
            }
        }

        [HttpPost("Add")]
        public ActionResult<Author> CreateAuthor(Author author)
        {
            try
            {
                if (author == null)
                {
                    return BadRequest();
                }

                _authorService.Add(author);
                //_baseService.Add(author);

                return CreatedAtAction(nameof(CreateAuthor), new { id = author.Id }, author);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new author record!");
            }
        }

        [HttpDelete("Delete")]
        public ActionResult<Author> DeleteAuthor(int id)
        {
            try
            {
                var author = _authorService.GetAuthorById(id);
                //var getAuthorById = _baseService.Get(author.Id);

                if (author == null)
                {
                    return NotFound($"Project with Id = {id} not found!");
                }

                //_baseService.Delete(getAuthorById);
                _authorService.Delete(author);

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
