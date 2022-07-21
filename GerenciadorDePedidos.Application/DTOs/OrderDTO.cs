using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Application.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "O campo Quantidade de produtos é obrigatório")]
        [Range(1, 9999)]
        public int Quantity { get; set; }

    }
}
