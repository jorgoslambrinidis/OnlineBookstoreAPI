namespace OnlineBookstore.Service.Interfaces
{
    using OnlineBookstore.Entities;
    using System.Collections.Generic;

    public interface IShopCartService
    {
        void Add(ShopCart shopCart);

        void Edit(ShopCart shopCart);

        void Delete(ShopCart shopCart);

        ShopCart GetShopCartById(int id);

        IEnumerable<ShopCart> GetAllShopCarts();
    }
}
