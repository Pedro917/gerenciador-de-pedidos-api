

using GerenciadorDePedidos.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<IList<SupplierDTO>> GetAll();
        Task<SupplierDTO> GetById(int id);
        Task<SupplierDTO> Add(SupplierDTO supplierDto);
        Task<SupplierDTO> Update(SupplierDTO supplierDto);
        Task Remove(int id);
    }
}
