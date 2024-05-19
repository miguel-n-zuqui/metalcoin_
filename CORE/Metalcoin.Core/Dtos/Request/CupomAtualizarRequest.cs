using Metalcoin.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Dtos.Request
{
    public class CupomAtualizarRequest
    {
        [Required]
        public Guid Id { get; set; }
        [MaxLength(100, ErrorMessage = "Cupom pode ter no máximo 100 letras")]
        public string Descricao { get; set; }
        public decimal ValorDesconto { get; set; }
        public TipoDesconto TipoDescontoCupon { get; set; }
        public TipoStatusCupom statusCupom { get; set; }
        public DateTime DataValidade { get; set; }

    }
}
