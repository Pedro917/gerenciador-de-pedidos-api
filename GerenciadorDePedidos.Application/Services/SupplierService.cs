using AutoMapper;
using GerenciadorDePedidos.Application.DTOs;
using GerenciadorDePedidos.Application.Interfaces;
using GerenciadorDePedidos.Application.Utilities;
using GerenciadorDePedidos.Domain.Entities;
using GerenciadorDePedidos.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public SupplierService(IMapper mapper, ISupplierRepository supplierRepository, IProductRepository productRepository)
        {
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<SupplierDTO> Add(SupplierDTO supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            var result = await _supplierRepository.CreateSupplier(supplier);
            return _mapper.Map<SupplierDTO>(result);
        }

        public async Task<IList<SupplierDTO>> GetAll()
        {
            var suppliers = await _supplierRepository.GetSuppliers();
            return _mapper.Map<IList<SupplierDTO>>(suppliers);
        }

        public async Task<SupplierDTO> GetById(int id)
        {
            var supplier = await _supplierRepository.GetSupplierById(id);
            return _mapper.Map<SupplierDTO>(supplier);
        }

        public async Task Remove(int id)
        {
            var supplier = await _supplierRepository.GetSupplierById(id);
            await _supplierRepository.RemoveSupplier(supplier);
        }

        public async Task<SupplierDTO> Update(SupplierDTO supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            await _supplierRepository.UpdateSupplier(supplier);
            return await GetById(supplier.Id);
        }

        public async Task<IList<OrderDTO>> GetOrdersBySupplier(int id)
        {
            var orders = await _supplierRepository.GetOrdersBySupplier(id);

            foreach (var order in orders)
            {
                order.Product = await _productRepository.GetProductById(order.ProductId);
                order.TotalAmount = PriceUtilities.CalculateTotalAmount(order);
            }

            return _mapper.Map<List<OrderDTO>>(orders);
        }
    }
}
