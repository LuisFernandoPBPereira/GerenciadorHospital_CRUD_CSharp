using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Application.DTOs.Responses;

public class PacienteResponseDto
{
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public DateTime DataNasc { get; set; }
    public bool TemConvenio { get; set; }
    public string? ImgCarteiraDoConvenio { get; set; }
    public string? ImgDocumento { get; set; }
    public int? ConvenioId { get; set; }

    public PacienteResponseDto(PacienteEntity paciente)
    {
        Nome = paciente.Nome;
        Cpf = paciente.Cpf;
        Endereco = paciente.Endereco;
        DataNasc = paciente.DataNasc;
        TemConvenio = paciente.TemConvenio;
        ImgCarteiraDoConvenio = paciente.ImgCarteiraDoConvenio;
        ImgDocumento = paciente.ImgDocumento;
        ConvenioId = paciente.ConvenioId;
    }
}
