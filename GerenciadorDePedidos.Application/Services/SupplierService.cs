using AutoMapper;
using GerenciadorDePedidos.Application.DTOs;
using GerenciadorDePedidos.Application.Interfaces;
using GerenciadorDePedidos.Domain.Entities;
using GerenciadorDePedidos.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
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
    }
}
