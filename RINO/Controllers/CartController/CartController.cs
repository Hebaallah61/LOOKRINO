using Microsoft.AspNetCore.Mvc;
using RINO.Repo.DeviceRepo;
using RINO.Repos.ShoppingCartItemsRepo;
using RINO.ViewModels;
using System.Security.Cryptography;

namespace RINO.Controllers.CartController
{
    public class CartController : Controller
    {
        private readonly IDevice _device;
        private readonly IShoppingCart _shoppingCart;
        public CartController(IDevice device,IShoppingCart shoppingCart)
        {
            _device = device;
            _shoppingCart= shoppingCart;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var CartViewModel = new CartViewModel(_shoppingCart, _shoppingCart.GetCartPrice());
            return View(CartViewModel);
        }

        public RedirectToActionResult AddToCart(int did)
        {
            var selecteddevice= _device.AllDevices.FirstOrDefault(d=>d.DeviceId==did);
            if(selecteddevice!=null)
            {
                _shoppingCart.AddToCart(selecteddevice);

            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int did)
        {
            var selecteddevice = _device.AllDevices.FirstOrDefault(d => d.DeviceId == did);
            if (selecteddevice != null)
            {
                _shoppingCart.RemoveFromCart(selecteddevice);

            }
            return RedirectToAction("Index");
        }

    }
}
