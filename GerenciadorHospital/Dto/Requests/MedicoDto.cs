using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorHospital.Dto.Requests
{
    public class MedicoDto
    {
        public string Nome { get; set; } = string.Empty;
        [RegularExpression(Consts.RegexCPF, ErrorMessage = Consts.ErroDeValidacaoCPF)]
        public string Cpf { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile? Doc { get; set; }
        public string Senha { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataNasc { get; set; }
        public string Crm { get; set; } = string.Empty;
        public string Especializacao { get; set; } = string.Empty;
    }
}
