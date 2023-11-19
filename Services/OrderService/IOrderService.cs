using RestaurantApi.Models;
using RestaurantApi.Models.OrderModel;

namespace RestaurantApi.Services.OrderService
{
    public interface IOrderService
    {
        List<Order> Get();
        Order Get(string id);
        Order Create(Order order);
        void Update(string id, Order order);
        void Remove(string id);
    }
}
