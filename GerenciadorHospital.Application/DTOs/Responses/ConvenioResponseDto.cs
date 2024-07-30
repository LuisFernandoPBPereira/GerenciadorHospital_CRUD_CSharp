using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Application.DTOs.Responses;

public class ConvenioResponseDto
{
    public string Nome { get; set; } = string.Empty;
    public float Preco { get; set; }

    public ConvenioResponseDto(ConvenioEntity convenioEntity)
    {
        Nome = convenioEntity.Nome;
        Preco = convenioEntity.Preco;
    }
}
