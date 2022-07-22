using GerenciadorDePedidos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task RemoveProduct(Product product);
    }
}
