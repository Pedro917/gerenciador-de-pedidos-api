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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SupplierRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Supplier> CreateSupplier(Supplier supplier)
        {
            _dbContext.Suppliers.Add(supplier);
            await _dbContext.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier> GetSupplierById(int id)
        {
            return await _dbContext.Suppliers.FindAsync(id);
        }

        public async Task<IList<Supplier>> GetSuppliers()
        {
            return await _dbContext.Suppliers.ToListAsync();
        }

        public async Task RemoveSupplier(Supplier supplier)
        {
            _dbContext.Suppliers.Remove(supplier);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            _dbContext.Suppliers.Update(supplier);
            await _dbContext.SaveChangesAsync();
            return await GetSupplierById(supplier.Id);
        }
    }
}
