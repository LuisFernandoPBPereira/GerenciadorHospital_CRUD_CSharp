using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Dto.Responses
{
    public class ConsultaResponseDto
    {
        public int Id { get; set; }
        public DateTime DataConsulta { get; set; }
        public DateTime? DataRetorno { get; set; }
        public decimal? Valor { get; set; }
        public StatusConsulta EstadoConsulta { get; set; }
        public List<LaudoModel>? Laudos { get; set; }
        public TipoExameModel? Exame { get; set; }
        public PacienteResponseDto? Paciente { get; set; }
        public MedicoResponseDto? Medico { get; set; }

        public ConsultaResponseDto(RegistroConsultaModel consulta)
        {
            Id = consulta.Id;
            DataConsulta = consulta.DataConsulta;
            DataRetorno = consulta.DataRetorno;
            Valor = consulta.Valor;
            Laudos = consulta.Laudo.ToList();
            Paciente = new PacienteResponseDto(consulta.Paciente);
            Medico = new MedicoResponseDto(consulta.Medico);
            Exame = consulta.Exame;
        }
    }
}
