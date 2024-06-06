using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateNewOrder(Order order);
    }
}