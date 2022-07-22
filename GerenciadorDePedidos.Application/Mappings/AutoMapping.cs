
using AutoMapper;
using GerenciadorDePedidos.Application.DTOs;
using GerenciadorDePedidos.Domain.Entities;

namespace GerenciadorDePedidos.Application.Mappings
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
