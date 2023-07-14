namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class UserController : BaseApiController<UserController>
    {
        private readonly IUserService _userService;
        private readonly IBaseService<User> _baseService;

        public UserController(
            IUserService userService,
            IBaseService<User> baseService
        )
        {
            _userService = userService;
            _baseService = baseService;
        }

        [HttpGet("Users")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                //var users = _baseService.GetAll();

                if (users == null)
                {
                    //return StatusCode(StatusCodes.Status404NotFound, "The list is empty");
                    return NotFound();
                }
                else
                {
                    Logger.LogInformation("All shop carts all taken from th db.");
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.ErrorRetievingDataFromDB);
            }

        }
    }
}
