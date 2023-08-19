using RINO.Context;
using RINO.Models;
using RINO.Repos.ShoppingCartItemsRepo;

namespace RINO.Repos.OrderRepo
{
    public class OrderRepo:IOrder
    {
        private readonly RinoDbContext _context;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepo(RinoDbContext context, IShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced=DateTime.Now;
            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetCartPrice();
            order.orderDetails = new List<OrderDetail>();
            foreach(ShoppingCartItem shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    DeviceId = shoppingCartItem.Device.DeviceId,
                    Price = (decimal)shoppingCartItem.Device.Price
                };
                order.orderDetails.Add(orderDetail);
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
