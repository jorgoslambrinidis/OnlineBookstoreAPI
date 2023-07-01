namespace OnlineBookstore.Services
{
    using OnlineBookstore.Entities;
    using OnlineBookstore.Repository.Interfaces;
    using OnlineBookstore.Service.Interfaces;
    using System.Collections.Generic;

    public class ShopCartService : IShopCartService
    {
        private readonly IShopCartRepository _shopCartRepository;

        public ShopCartService(IShopCartRepository shopCartRepository)
        {
            _shopCartRepository = shopCartRepository;
        }

        public void Add(ShopCart shopCart)
        {
            _shopCartRepository.Add(shopCart);
        }

        public void Delete(ShopCart shopCart)
        {
            _shopCartRepository.Delete(shopCart);
        }

        public void Edit(ShopCart shopCart)
        {
            _shopCartRepository.Edit(shopCart);
        }

        public IEnumerable<ShopCart> GetAllShopCarts()
        {
            var result = _shopCartRepository.GetAllShopCarts();
            return result;
        }

        public ShopCart GetShopCartById(int id)
        {
            var result = _shopCartRepository.GetShopCartById(id);
            return result;
        }
    }
}
