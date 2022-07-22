using GerenciadorDePedidos.Domain.Entities;
using GerenciadorDePedidos.Domain.Interfaces;
using GerenciadorDePedidos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Infrastructure.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Order> CreateOrder(Order Order)
        {
            _dbContext.Orders.Add(Order);
            await _dbContext.SaveChangesAsync();
            return Order;
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _dbContext.Orders.FindAsync(id);
        }

        public async Task<IList<Order>> GetOrders()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task RemoveOrder(Order Order)
        {
            _dbContext.Orders.Remove(Order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Order> UpdateOrder(Order Order)
        {
            _dbContext.Orders.Update(Order);
            await _dbContext.SaveChangesAsync();
            return await GetOrderById(Order.Id);
        }
    }
}
