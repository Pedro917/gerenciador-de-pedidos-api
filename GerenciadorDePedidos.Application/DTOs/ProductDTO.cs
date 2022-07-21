using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [MinLength(3, ErrorMessage = "Tamanho do {0} está errado")]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "O campo Valor do produto é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

    }
}
