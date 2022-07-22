

using GerenciadorDePedidos.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IList<OrderDTO>> GetAll();
        Task<OrderDTO> GetById(int id);
        Task<OrderDTO> Add(OrderDTO orderDto);
        Task<OrderDTO> Update(OrderDTO orderDto);
        Task Remove(int id);
    }
}
