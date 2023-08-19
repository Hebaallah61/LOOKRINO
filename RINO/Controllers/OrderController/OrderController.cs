using Microsoft.AspNetCore.Mvc;
using RINO.Models;
using RINO.Repos.OrderRepo;
using RINO.Repos.ShoppingCartItemsRepo;

namespace RINO.Controllers.OrderController
{
    public class OrderController : Controller
    {

        private readonly IOrder _order;
        private readonly IShoppingCart _shoppingCart;

        public OrderController(IOrder order, IShoppingCart shoppingCart)
        {
            _order = order;
            _shoppingCart = shoppingCart;
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            var items=_shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems= items;
            if(_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "You Cart Is Empty");
            }
            if(ModelState.IsValid)
            {
                _order.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckOutComplete");
            }
            return View(order);
        }


        public IActionResult CheckOutComplete()
        {
            ViewBag.Message = "Thank You For Your Order";
            return View();
        }
    }
}
