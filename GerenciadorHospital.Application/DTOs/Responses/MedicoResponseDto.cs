using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Application.DTOs.Responses;

public class MedicoResponseDto
{
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string? CaminhoDoc { get; set; }
    public string Endereco { get; set; } = string.Empty;
    public DateTime DataNasc { get; set; }
    public string Crm { get; set; } = string.Empty;
    public string Especializacao { get; set; } = string.Empty;

    public MedicoResponseDto(MedicoEntity medico)
    {
        Nome = medico.Nome;
        Cpf = medico.Cpf;
        CaminhoDoc = medico.CaminhoDoc;
        Endereco = medico.Endereco;
        DataNasc = medico.DataNasc;
        Crm = medico.Crm;
        Especializacao = medico.Especializacao;
    }
}
