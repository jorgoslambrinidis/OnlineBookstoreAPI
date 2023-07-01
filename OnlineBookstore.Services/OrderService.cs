namespace OnlineBookstore.Services
{
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using OnlineBookstore.Service.Interfaces;
    using System.Collections.Generic;

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Add(Order order)
        {
            _orderRepository.Add(order);
        }

        public void Delete(Order order)
        {
            _orderRepository.Delete(order);
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
        }

        public void DeleteByUserId(string userId)
        {
            _orderRepository.DeleteByUserId(userId);
        }

        public void Edit(Order order)
        {
            _orderRepository.Edit(order);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var result = _orderRepository.GetAllOrders();
            return result;
        }

        public IEnumerable<Order> GetAllOrdersByUserId(string userId)
        {
            var result = _orderRepository.GetAllOrdersByUserId(userId);
            return result;
        }

        public Order GetOrderById(int id)
        {
            var result = _orderRepository.GetOrderById(id);
            return result;
        }

        public Order GetOrderByUserId(string userId)
        {
            var result = _orderRepository.GetOrderByUserId(userId);
            return result;
        }
    }
}
