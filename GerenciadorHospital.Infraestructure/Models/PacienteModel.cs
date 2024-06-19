using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorHospital.Models
{
    public class PacienteModel
    {
        // Doc: O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        #pragma warning disable CS8618
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
        //public IFormFile Doc { get; set; }
        //[NotMapped]
        //public IFormFile? DocConvenio { get; set; }
        public int? ConvenioId { get; set; }
        public virtual ConvenioModel? Convenio {  get; set; }

        public PacienteModel() {   }
    }
}
