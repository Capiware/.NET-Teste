using Capiware.Technologies.TesteTecnico.WebApi.Domain;
using System.ComponentModel.DataAnnotations;

namespace Capiware.Technologies.TesteTecnico.WebApi.ViewModel
{
    public class ServicoViewModel
    {
        [Required]
        public string Nome { get; set; }
        public StatusEnum Status { get; set; }
        public Decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}