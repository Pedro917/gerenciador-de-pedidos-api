using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Domain.Entities
{
    public sealed class Supplier: Entity
    {
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public string Uf { get; set; }
        public string ContactEmail { get; set; }
        public string ContactName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
