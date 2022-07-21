using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Domain.Entities
{
    public sealed class Product: Entity
    {
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
    }
}
