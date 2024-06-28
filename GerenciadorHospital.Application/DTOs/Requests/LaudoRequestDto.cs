using Microsoft.AspNetCore.Http;

namespace GerenciadorHospital.Application.DTOs.Requests;

public class LaudoResponseDto
{
    public string Descricao { get; set; } = string.Empty;
    public DateTime? DataCriacao { get; set; }
    public IFormFile? ImagemLaudo { get; set; }
    public string? CaminhoImagemLaudo { get; set; }
    public int? PacienteId { get; set; }
    public int? MedicoId { get; set; }
    public int? MedicamentoId { get; set; }
    public int? RegistroConsultaModelId { get; set; }
}
