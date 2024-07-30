using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Application.DTOs.Responses;

public class TipoExameResponseDto
{
    public string Nome { get; set; } = string.Empty;
    public int? PacienteId { get; set; }
    public int? MedicoId { get; set; }

    public TipoExameResponseDto(TipoExameEntity exame)
    {
        Nome = exame.Nome;
        PacienteId = exame.PacienteId;
        MedicoId = exame.MedicoId;
    }
}
