using GerenciadorDePedidos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IList<Order>> GetOrders();
        Task<Order> GetOrderById(int id);
        Task<Order> CreateOrder(Order Order);
        Task<Order> UpdateOrder(Order Order);
        Task RemoveOrder(Order Order);
    }
}
