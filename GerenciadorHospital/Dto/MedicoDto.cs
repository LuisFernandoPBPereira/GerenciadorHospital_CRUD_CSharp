using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorHospital.Dto
{
    public class MedicoDto
    {
        public string Nome { get; set; }
        [RegularExpression(Consts.RegexCPF, ErrorMessage = Consts.ErroDeValidacaoCPF)]
        public string Cpf { get; set; }
        [NotMapped]
        public IFormFile? Doc { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNasc { get; set; }
        public string Crm { get; set; }
        public string Especializacao { get; set; }
    }
}
