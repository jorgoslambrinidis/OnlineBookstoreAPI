namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class OrderController : BaseApiController<OrderController>
    {
        private readonly IOrderService _orderService;
        private readonly IBaseService<Order> _baseService;

        public OrderController(
            IOrderService orderService,
            IBaseService<Order> baseService
        )
        {
            _orderService = orderService;
            _baseService = baseService;
        }

        [HttpGet("Orders")]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            try
            {
                var orders = _orderService.GetAllOrders();
                //var orders = _baseService.GetAll();

                if (orders == null)
                {
                    //return StatusCode(StatusCodes.Status404NotFound, "The list is empty");
                    return NotFound();
                }
                else
                {
                    Logger.LogInformation("All orders all taken from th db.");
                    return Ok(orders);
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
