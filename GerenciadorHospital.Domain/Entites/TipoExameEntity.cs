namespace GerenciadorHospital.Models
{
    public class TipoExameEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public virtual PacienteEntity? Paciente { get; set; }
        public virtual MedicoEntity? Medico { get; set; }

        public TipoExameEntity() {    }
    }
}
