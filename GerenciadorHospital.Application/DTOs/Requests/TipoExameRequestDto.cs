namespace GerenciadorHospital.Application.DTOs.Requests;

public class TipoExameRequestDto
{
    public string Nome { get; set; } = string.Empty;
    public int? PacienteId { get; set; }
    public int? MedicoId { get; set; }
}
