namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class ShopController : BaseApiController<ShopController>
    {
        private readonly IShopCartService _shopCartService;

        public ShopController(IShopCartService shopCartService)
        {
            _shopCartService = shopCartService;
        }

        [HttpGet("Shopcarts")]
        public ActionResult<IEnumerable<ShopCart>> GetAllShopcarts()
        {
            try
            {
                var shopcarts = _shopCartService.GetAllShopCarts();

                if (shopcarts == null)
                {
                    //return StatusCode(StatusCodes.Status404NotFound, "The list is empty");
                    return NotFound();
                }
                else
                {
                    Logger.LogInformation("All shop carts all taken from th db.");
                    return Ok(shopcarts);
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
