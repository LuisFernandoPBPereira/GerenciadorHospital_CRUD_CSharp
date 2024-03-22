namespace GerenciadorHospital.Models
{
    public class PacienteModel : UsuarioModel
    {
        public bool TemConvenio { get; set; }
        public string? ImgCarteiraDoConvenio { get; set; }
        public string? ImgDocumento { get; set; }
        /*
         * Pegamos o ID do convenio e do medicamento,
         * além de pegarmos os objetos convenio e medicamento
        */
        public int? ConvenioId { get; set; }
        public int? MedicamentoId { get; set; }
        public int? ExameId { get; set; }
        public virtual ConvenioModel? Convenio {  get; set; }
        public virtual MedicamentoPacienteModel? Medicamento {  get; set; }
        public virtual TipoExameModel? Exame {  get; set; }

    }
}
