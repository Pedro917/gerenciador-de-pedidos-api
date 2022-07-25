

using GerenciadorDePedidos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Domain.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IList<Supplier>> GetSuppliers();
        Task<Supplier> GetSupplierById(int id);
        Task<Supplier> CreateSupplier(Supplier supplier);
        Task<Supplier> UpdateSupplier(Supplier supplier);
        Task RemoveSupplier(Supplier supplier);
        Task<IList<Order>> GetOrdersBySupplier(int id);
    }
}
