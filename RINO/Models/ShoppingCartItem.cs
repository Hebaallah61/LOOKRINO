using Microsoft.EntityFrameworkCore;

namespace RINO.Models
{
    public class ShoppingCartItem
    {
       
        public int ShoppingCartItemId { get; set; } 
        public Device? Device { get; set; }
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; }
    }
}
