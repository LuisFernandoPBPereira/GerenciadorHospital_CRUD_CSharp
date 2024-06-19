namespace GerenciadorHospital.Models
{
    public class RegistroConsultaEntity
    {
        public int Id { get; set; }
        public DateTime DataConsulta {  get; set; }
        public decimal? Valor { get; set; }
        public DateTime? DataRetorno { get; set; }
        //public StatusConsulta? EstadoConsulta { get; set; }
        public bool Retorno { get; set; }
        public int PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public int? ExameId { get; set; }
        public virtual PacienteEntity? Paciente { get; set; }
        public virtual MedicoEntity? Medico { get; set; }
        public virtual ICollection<LaudoEntity>? Laudo { get; set; }
        public virtual TipoExameEntity? Exame { get; set; }

        public RegistroConsultaEntity() {    }
    }
}
