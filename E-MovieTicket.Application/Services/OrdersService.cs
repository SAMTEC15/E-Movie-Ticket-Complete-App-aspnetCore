using E_MovieTicket.Application.Interfaces;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Repositories;

namespace E_MovieTicket.Application.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole) => _orderRepository.GetOrderByUserIdAndRoleAsync(userId, userRole);
       

        public Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress) => _orderRepository.StoreOrderAsync(items, userId, userEmailAddress);
    
    }
}
