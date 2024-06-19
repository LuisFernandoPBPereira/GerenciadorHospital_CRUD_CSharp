namespace GerenciadorHospital.Models
{
    public class RegistroConsultaModel
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
        public virtual PacienteModel? Paciente { get; set; }
        public virtual MedicoModel? Medico { get; set; }
        public virtual ICollection<LaudoModel>? Laudo { get; set; }
        public virtual TipoExameModel? Exame { get; set; }

        public RegistroConsultaModel() {    }
    }
}
