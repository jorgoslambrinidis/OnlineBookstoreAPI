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
            var shopcarts = _shopCartService.GetAllShopCarts();
            return Ok(shopcarts);
        }
    }
}
