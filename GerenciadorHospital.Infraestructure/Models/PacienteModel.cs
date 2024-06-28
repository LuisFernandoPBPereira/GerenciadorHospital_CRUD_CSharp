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
        public int? ConvenioId { get; set; }
        public virtual ConvenioModel? Convenio {  get; set; }

        public PacienteModel() {   }
    }
}
