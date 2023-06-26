namespace OnlineBookstore.Repository.Interfaces
{
    using OnlineBookstore.Entities;
    using System.Collections.Generic;

    public interface IOrderRepository
    {
        void Add(Order order);

        void Edit(Order order);

        void Delete(Order order);

        void Delete(int id);

        void DeleteByUserId(string userId);


        Order GetOrderById(int id);

        Order GetOrderByUserId(string userId);

        IEnumerable<Order> GetAllOrders();

        IEnumerable<Order> GetAllOrdersByUserId(string userId);
    }
}
