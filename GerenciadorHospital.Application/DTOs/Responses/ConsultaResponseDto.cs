using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Enums;

namespace GerenciadorHospital.Application.DTOs.Responses;

public class ConsultaResponseDto
{
    public DateTime DataConsulta { get; set; }
    public DateTime? DataRetorno { get; set; }
    public decimal? Valor { get; set; }
    public StatusConsulta EstadoConsulta { get; set; }
    public bool Retorno { get; set; }
    public int PacienteId { get; set; }
    public int? MedicoId { get; set; }
    public int? ExameId { get; set; }

    public ConsultaResponseDto(RegistroConsultaEntity consulta)
    {
        DataConsulta = consulta.DataConsulta;
        DataRetorno = consulta.DataRetorno;
        Valor = consulta.Valor;
        EstadoConsulta = consulta.EstadoConsulta;
        Retorno = consulta.Retorno;
        PacienteId = consulta.PacienteId;
        MedicoId = consulta.MedicoId;
        ExameId = consulta.ExameId;
    }
}
