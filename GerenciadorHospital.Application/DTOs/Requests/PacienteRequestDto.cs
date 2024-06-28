using Microsoft.AspNetCore.Http;

namespace GerenciadorHospital.Application.DTOs.Requests;

public class PacienteResponseDto
{
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public DateTime DataNasc { get; set; }
    public bool TemConvenio { get; set; }
    public string? ImgCarteiraDoConvenio { get; set; }
    public string? ImgDocumento { get; set; }
    public IFormFile Doc { get; set; }
    public IFormFile? DocConvenio { get; set; }
    public int? ConvenioId { get; set; }
}
