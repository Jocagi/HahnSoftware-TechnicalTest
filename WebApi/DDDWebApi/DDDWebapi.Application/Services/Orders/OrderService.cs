using DDDWebapi.Application.Common.Interfaces.Objects;
using DDDWebapi.Domain.Entities;

namespace DDDWebapi.Application.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _orderRepository.GetOrdersAsync();
        }

        public async Task<Order> GetOrderAsync(Guid id)
        {
            return await _orderRepository.GetOrderAsync(id);
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            // Do some business logic here
            return await _orderRepository.AddOrderAsync(order);
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            // Do some business logic here
            return await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            // Do some business logic here
            await _orderRepository.DeleteOrderAsync(id);
        }
    }
}
