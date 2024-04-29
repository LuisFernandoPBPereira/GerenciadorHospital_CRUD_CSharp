using GerenciadorHospital.Enums;

namespace GerenciadorHospital.Dto
{
    public class RegistroConsultaDto
    {
        public DateTime DataConsulta { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? DataRetorno { get; set; }
        public StatusConsulta? EstadoConsulta { get; set; }
        public bool Retorno { get; set; }
        public int PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public int? ExameId { get; set; }
    }
}
