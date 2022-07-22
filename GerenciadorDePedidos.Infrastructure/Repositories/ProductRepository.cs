using GerenciadorDePedidos.Domain.Entities;
using GerenciadorDePedidos.Domain.Interfaces;
using GerenciadorDePedidos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Infrastructure.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Product> CreateProduct(Product Product)
        {
            _dbContext.Products.Add(Product);
            await _dbContext.SaveChangesAsync();
            return Product;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<IList<Product>> GetProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task RemoveProduct(Product Product)
        {
            _dbContext.Products.Remove(Product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> UpdateProduct(Product Product)
        {
            _dbContext.Products.Update(Product);
            await _dbContext.SaveChangesAsync();
            return await GetProductById(Product.Id);
        }
    }
}
