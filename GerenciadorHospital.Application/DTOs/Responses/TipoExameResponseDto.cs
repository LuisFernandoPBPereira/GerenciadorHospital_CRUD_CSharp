namespace GerenciadorHospital.Application.DTOs.Responses;

public class TipoExameResponseDto
{
    public string Nome { get; set; } = string.Empty;
    public int? PacienteId { get; set; }
    public int? MedicoId { get; set; }
}
