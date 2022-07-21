using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Application.DTOs
{
    public class SupplierDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Razão Social é obrigatório")]
        [MinLength(3, ErrorMessage = "Tamanho do {0} está errado")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "O campo Cnpj é obrigatório")]
        [StringLength(14, ErrorMessage = "Tamanho do {0} está errado")]
        public string Cnpj { get; set; }

        [StringLength(2, ErrorMessage = "Tamanho do {0} está errado")]
        public string Uf { get; set; }

        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }

        [MinLength(3, ErrorMessage = "Tamanho do {0} está errado")]
        public string ContactName { get; set; }
    }
}
