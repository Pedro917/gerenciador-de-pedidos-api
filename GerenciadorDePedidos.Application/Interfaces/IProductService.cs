

using GerenciadorDePedidos.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Application.Interfaces
{
    public interface IProductService
    {
        Task<IList<ProductDTO>> GetAll();
        Task<ProductDTO> GetById(int id);
        Task<ProductDTO> Add(ProductDTO productDto);
        Task<ProductDTO> Update(ProductDTO productDto);
        Task Remove(int id);
    }
}
