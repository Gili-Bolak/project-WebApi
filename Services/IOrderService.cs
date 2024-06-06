using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> CreateNewOrder(Order order);
    }
}