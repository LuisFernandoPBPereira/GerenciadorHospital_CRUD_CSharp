namespace GerenciadorHospital.Application.DTOs.Requests;

public class MedicamentoResponseDto
{
    public string Nome { get; set; } = string.Empty;
    public string Composicao { get; set; } = string.Empty;
    public DateTime DataFabricacao { get; set; }
    public DateTime DataValidade { get; set; }
}
