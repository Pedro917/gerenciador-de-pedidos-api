using GerenciadorDePedidos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Application.Utilities
{
    public static class PriceUtilities
    {
        public static decimal CalculateTotalAmount(Order order)
        {
            decimal amount = order.Product.Price * order.Quantity;
            return amount > 0 ? Math.Round(amount, 2) : 0;
        }
    }
}
