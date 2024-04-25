using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorHospital.Dto
{
    public class PacienteDto
    {
        public string Nome { get; set; }
        [RegularExpression(Consts.RegexCPF, ErrorMessage = Consts.ErroDeValidacaoCPF)]
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNasc { get; set; }
        public bool TemConvenio { get; set; }
        [NotMapped]
        public IFormFile Doc { get; set; }
        [NotMapped]
        public IFormFile? DocConvenio { get; set; }
        public int? ConvenioId { get; set; }
    }
}
