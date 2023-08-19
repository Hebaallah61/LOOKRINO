using Microsoft.AspNetCore.Mvc;
using RINO.Repos.ShoppingCartItemsRepo;
using RINO.ViewModels;

namespace RINO.Components
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var CartViewModel = new CartViewModel(_shoppingCart, _shoppingCart.GetCartPrice());
            return View(CartViewModel);
        }
    }
}
