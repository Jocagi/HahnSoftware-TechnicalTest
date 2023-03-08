using DDDWebapi.Domain.Entities;

namespace DDDWebapi.Application.Common.Interfaces.Objects
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(Guid id);
        Task<Order> AddOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Guid id);
    }
}
