using RINO.Models;

namespace RINO.Repos.ShoppingCartItemsRepo
{
    public interface IShoppingCart
    {
        void AddToCart(Device device);
        int RemoveFromCart(Device device);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetCartPrice();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
