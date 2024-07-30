using GerenciadorHospital.Application.DTOs.Responses;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Laudo;

public class LaudoPorIdUseCase
{
    private readonly ILaudo _laudo;

    public LaudoPorIdUseCase(ILaudo laudo)
    {
        _laudo = laudo;
    }

    public async Task<LaudoResponseDto> Executar(int id)
    {
        var laudoEntity = await _laudo.BuscarPorId(id);
        var responseLaudo = new LaudoResponseDto(laudoEntity);

        return responseLaudo;
    }
}
