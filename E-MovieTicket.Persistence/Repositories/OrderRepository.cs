using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EMovieTicketDbContext _eMovieTicketDbContext;
        public OrderRepository(EMovieTicketDbContext eMovieTicketDbContext)
        {
            _eMovieTicketDbContext = eMovieTicketDbContext;
        }
        public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _eMovieTicketDbContext.Orders.Include(o => o.OrderItems).ThenInclude(u => u.Movie).Include(u => u.User).ToListAsync();
            if (userRole != "Admin")
            {
                orders = orders.Where(u => u.UserId == userId).ToList();
            }
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _eMovieTicketDbContext.Orders.AddAsync(order);
            await _eMovieTicketDbContext.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price,
                };
                await _eMovieTicketDbContext.OrderItems.AddAsync(orderItem);
                await _eMovieTicketDbContext.SaveChangesAsync();
            }
        }
    }
}
