using RINO.Repo.DeviceRepo;
using RINO.Repos.ShoppingCartItemsRepo;

namespace RINO.ViewModels
{
    public class CartViewModel
    {
        public IShoppingCart ShoppingCart { get; }
        public decimal Price { get; }
        public CartViewModel(IShoppingCart shoppingCart,decimal price)
        {
            ShoppingCart = shoppingCart;
            Price = price;
        }
    }
}
