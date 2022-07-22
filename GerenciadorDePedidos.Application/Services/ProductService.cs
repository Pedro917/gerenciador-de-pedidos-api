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
    public class ProductService: IProductService
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Add(ProductDTO ProductDto)
        {
            var product = _mapper.Map<Product>(ProductDto);
            var result = await _ProductRepository.CreateProduct(product);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<IList<ProductDTO>> GetAll()
        {
            var products = await _ProductRepository.GetProducts();
            return _mapper.Map<IList<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var product = await _ProductRepository.GetProductById(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task Remove(int id)
        {
            var product = await _ProductRepository.GetProductById(id);
            await _ProductRepository.RemoveProduct(product);
        }

        public async Task<ProductDTO> Update(ProductDTO ProductDto)
        {
            var product = _mapper.Map<Product>(ProductDto);
            await _ProductRepository.UpdateProduct(product);
            return await GetById(product.Id);
        }
    }
}
