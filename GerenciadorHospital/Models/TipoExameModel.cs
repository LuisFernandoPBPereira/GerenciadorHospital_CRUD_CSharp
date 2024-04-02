namespace GerenciadorHospital.Models
{
    public class TipoExameModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public virtual PacienteModel? Paciente { get; set; }
        public virtual MedicoModel? Medico { get; set; }
    }
}
