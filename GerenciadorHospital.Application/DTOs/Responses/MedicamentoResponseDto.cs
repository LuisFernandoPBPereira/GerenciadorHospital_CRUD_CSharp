using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Application.DTOs.Responses;

public class MedicamentoResponseDto
{
    public string Nome { get; set; } = string.Empty;
    public string Composicao { get; set; } = string.Empty;
    public DateTime DataFabricacao { get; set; }
    public DateTime DataValidade { get; set; }

    public MedicamentoResponseDto(MedicamentoEntity medicamento)
    {
        Nome = medicamento.Nome;
        Composicao = medicamento.Composicao;
        DataFabricacao = medicamento.DataFabricacao;
        DataValidade = medicamento.DataValidade;
    }
}
