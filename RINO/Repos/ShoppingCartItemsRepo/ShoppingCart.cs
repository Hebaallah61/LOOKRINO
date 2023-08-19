using Microsoft.EntityFrameworkCore;
using RINO.Context;
using RINO.Models;

namespace RINO.Repos.ShoppingCartItemsRepo
{
    public class ShoppingCart : IShoppingCart
    {

        private readonly RinoDbContext _context;
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(RinoDbContext context)
        {
            _context = context;
            
        }
        //run check if cart id for this user if not it will create it 
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session= services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            RinoDbContext context= services.GetService<RinoDbContext>()?? throw new Exception("Error initialzing");
            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId=cartId};

        }


        public void AddToCart(Device device)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Device.DeviceId == device.DeviceId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new Models.ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Device = device,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void ClearCart()
        {
            var CarItems=_context.ShoppingCartItems.Where(cart=>cart.ShoppingCartId==ShoppingCartId);
            _context.ShoppingCartItems.RemoveRange(CarItems);
            _context.SaveChanges(); 
        }

        public decimal GetCartPrice()
        {
            var totalPrice=_context.ShoppingCartItems.Where(c=>c.ShoppingCartId==ShoppingCartId).Select(c=>c.Device.Price*c.Amount).Sum();
            return (decimal)totalPrice!;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            if (ShoppingCartItems == null)
            {
                ShoppingCartItems = _context.ShoppingCartItems
                    .Where(c => c.ShoppingCartId == ShoppingCartId)
                    .Include(s => s.Device)
                    .ToList();
            }

            return ShoppingCartItems;
        }

        public int RemoveFromCart(Device device)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Device.DeviceId == device.DeviceId && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                } 
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
          
            _context.SaveChanges();
            return localAmount;
        }
    }
}
