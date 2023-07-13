namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class UserController : BaseApiController<UserController>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Users")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();

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
