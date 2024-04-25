using GerenciadorHospital.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorHospital.Models
{
    public class PacienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataNasc { get; set; }
        public bool TemConvenio { get; set; }
        public string? ImgCarteiraDoConvenio { get; set; }
        public string? ImgDocumento { get; set; }
        [NotMapped]
        public IFormFile Doc { get; set; }
        [NotMapped]
        public IFormFile? DocConvenio { get; set; }
        public int? ConvenioId { get; set; }
        public virtual ConvenioModel? Convenio {  get; set; }

        public PacienteModel() {   }

        public PacienteModel(PacienteDto pacienteDto)
        {
            Nome = pacienteDto.Nome;
            Cpf = pacienteDto.Cpf;
            Senha = pacienteDto.Senha;
            Endereco = pacienteDto.Endereco;
            DataNasc = pacienteDto.DataNasc;
            TemConvenio = pacienteDto.TemConvenio;
            Doc = pacienteDto.Doc;
            DocConvenio = pacienteDto?.DocConvenio;
            ConvenioId = pacienteDto?.ConvenioId;
        }
    }
}
