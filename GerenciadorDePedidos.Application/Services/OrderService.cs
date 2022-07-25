using AutoMapper;
using GerenciadorDePedidos.Application.DTOs;
using GerenciadorDePedidos.Application.Interfaces;
using GerenciadorDePedidos.Application.Utilities;
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
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _productRepository = productRepository;

        }

        public async Task<OrderDTO> Add(OrderDTO OrderDto)
        {
            var order = _mapper.Map<Order>(OrderDto);
            var result = await _orderRepository.CreateOrder(order);
            return _mapper.Map<OrderDTO>(result);
        }

        public async Task<IList<OrderDTO>> GetAll()
        {
            var orders = await _orderRepository.GetOrders();

            if (orders.Any())
            {
                foreach (var order in orders)
                {
                    order.Product = await _productRepository.GetProductById(order.ProductId);
                    order.TotalAmount = PriceUtilities.CalculateTotalAmount(order);
                }
            }

            return _mapper.Map<IList<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetById(int id)
        {
            var order = await _orderRepository.GetOrderById(id);

            if(order is not null)
            {
                order.Product = await _productRepository.GetProductById(order.ProductId);
                order.TotalAmount = PriceUtilities.CalculateTotalAmount(order);
            }

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task Remove(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            await _orderRepository.RemoveOrder(order);
        }

        public async Task<OrderDTO> Update(OrderDTO OrderDto)
        {
            var order = _mapper.Map<Order>(OrderDto);
            await _orderRepository.UpdateOrder(order);
            return await GetById(order.Id);
        }
    }
}
