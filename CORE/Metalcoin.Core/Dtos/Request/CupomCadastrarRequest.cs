using Metalcoin.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Dtos.Request
{
    public class CupomCadastrarRequest
    {
        [Required(ErrorMessage = "Este campo é obrigátorio")]
        [MaxLength(100, ErrorMessage = "Cupom pode ter no máximo 100 letras")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Este campo é obrigátorio")]
        public decimal ValorDesconto { get; set; }
        [Required(ErrorMessage = "Este campo é obrigátorio")]
        public TipoDesconto TipoDescontoCupon { get; set; }
        [Required(ErrorMessage = "Este campo é obrigátorio")]
        public TipoStatusCupom statusCupom { get; set; }
        [Required(ErrorMessage = "Este campo é obrigátorio")]
        public DateTime DataValidade { get; set; }
        [Required(ErrorMessage = "Este campo é obrigátorio")]
        public int QuantidadeLiberado { get; set; }
        [Required(ErrorMessage = "Este campo é obrigátorio")]
        public int QuantidadeUsado { get; set; }

    }
}
