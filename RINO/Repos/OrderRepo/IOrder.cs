using RINO.Models;

namespace RINO.Repos.OrderRepo
{
    public interface IOrder
    {
        void CreateOrder(Order order);
    }
}
