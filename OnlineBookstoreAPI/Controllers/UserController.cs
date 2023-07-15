namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// We are adding [Authorize] on top of the controller for auth restriction on this endpoint
        /// <para> * We have to Login first, get the generated token </para> 
        /// <para> * First, hit the auth/login endpoint </para> 
        /// <para> * Make a login as an user (admin user) </para> 
        /// <para> * Take the generated token </para> 
        /// <para> * and send the request as a "Bearer [token here]" in the "Authorization Tab" in Postman </para> 
        /// *** <b> Without the AUTH TOKEN WE CANNOT HIT this endpoint </b>
        /// </summary>
        /// <returns></returns>
        [Authorize]
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
