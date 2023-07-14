namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class CategoryController : BaseApiController<CategoryController>
    {
        private readonly ICategoryService _categoryService;
        private readonly IBaseService<Category> _baseService;

        public CategoryController(
            ICategoryService categoryService,
            IBaseService<Category> baseService
        )
        {
            _categoryService = categoryService;
            _baseService = baseService;
        }

        [HttpGet("Categories")]
        public ActionResult<IEnumerable<Category>> GetAllCategories()
        {
            try
            {
                var categories = _categoryService.GetAllCategories();
                //var categories = _baseService.GetAll();

                if (categories == null)
                {
                    return NotFound();
                }
                else
                {
                    Logger.LogInformation("All categories all taken from th db.");
                    return Ok(categories);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetievingDataFromDB);
            }
        }

        [HttpGet("Category")]
        public ActionResult<Category> GetCategory(int id)
        {
            try
            {
                var category = _categoryService.GetCategoryById(id);
                //var category = _baseService.Get(id);

                if (category == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(category);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetievingDataFromDB);
            }
        }

        [HttpPut("Edit")]
        public IActionResult EditCategory(Category category)
        {
            try
            {
                var categoryToEdit = _categoryService.GetCategoryById(category.Id);
                //var categoryToEdit = _baseService.Get(category.Id);

                if (categoryToEdit == null)
                {
                    return NotFound($"Category with Id = {category.Id} not found!");
                }

                _categoryService.Edit(category);
                //_baseService.Edit(category);

                return StatusCode(StatusCodes.Status202Accepted, category);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorUpdatingData);
            }
        }

        [HttpPost("Add")]
        public ActionResult<Category> AddCategory(Category category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest();
                }

                _categoryService.Add(category);
                //_baseService.Add(category);

                return CreatedAtAction(nameof(AddCategory), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new category record!");
            }
        }

        [HttpDelete("Delete")]
        public ActionResult<Category> DeleteCategory(int id)
        {
            try
            {
                var category = _categoryService.GetCategoryById(id);
                //var category = _baseService.Get(id);

                if (category == null)
                {
                    return NotFound($"Category with Id = {id} not found!");
                }

                _categoryService.Delete(category);
                //_baseService.Delete(category);

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
