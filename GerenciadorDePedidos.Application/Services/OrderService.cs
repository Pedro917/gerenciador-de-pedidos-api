using AutoMapper;
using GerenciadorDePedidos.Application.DTOs;
using GerenciadorDePedidos.Application.Interfaces;
using GerenciadorDePedidos.Domain.Entities;
using GerenciadorDePedidos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Application.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDTO> Add(OrderDTO OrderDto)
        {
            var order = _mapper.Map<Order>(OrderDto);
            var result = await _OrderRepository.CreateOrder(order);
            return _mapper.Map<OrderDTO>(result);
        }

        public async Task<IList<OrderDTO>> GetAll()
        {
            var orders = await _OrderRepository.GetOrders();
            return _mapper.Map<IList<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetById(int id)
        {
            var order = await _OrderRepository.GetOrderById(id);
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task Remove(int id)
        {
            var order = await _OrderRepository.GetOrderById(id);
            await _OrderRepository.RemoveOrder(order);
        }

        public async Task<OrderDTO> Update(OrderDTO OrderDto)
        {
            var order = _mapper.Map<Order>(OrderDto);
            await _OrderRepository.UpdateOrder(order);
            return await GetById(order.Id);
        }
    }
}
