namespace OnlineBookstoreAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;

    public class OrderController : BaseApiController<OrderController>
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("Orders")]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            try
            {
                var orders = _orderService.GetAllOrders();

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
