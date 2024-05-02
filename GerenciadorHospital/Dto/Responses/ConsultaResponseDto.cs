using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Dto.Responses
{
    public record ConsultaResponseDto(
        int Id,
        DateTime DataConsulta,
        DateTime? DataRetorno,
        decimal? Valor,
        StatusConsulta? EstadoConsulta,
        List<string>? Laudos,
        string? Exame,
        PacienteResponseDto? Paciente,
        MedicoResponseDto? Medico
    );
}
