using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Domain.Entities
{
    public sealed class Order: Entity
    {
        public DateTime CreatedAt { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount => CalculateTotalAmount();

        private decimal CalculateTotalAmount()
        {
            decimal amount = this.Product.Price * this.Quantity;
            return amount > 0 ? Math.Round(amount, 2) : 0;
        }
    }
}
