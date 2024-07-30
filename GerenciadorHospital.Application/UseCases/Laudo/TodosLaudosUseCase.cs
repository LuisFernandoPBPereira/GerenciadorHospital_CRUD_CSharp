using GerenciadorHospital.Application.DTOs.Responses;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Laudo;

public class TodosLaudosUseCase
{
    private readonly ILaudo _laudo;

    public TodosLaudosUseCase(ILaudo laudo)
    {
        _laudo = laudo;
    }

    public async Task<IEnumerable<LaudoResponseDto>> Executar()
    {
        var laudos = await _laudo.BuscarTodos();

        var laudosReponse = new List<LaudoResponseDto>();

        foreach (var laudo in laudos)
        {
            var laudoDto = new LaudoResponseDto(laudo);

            laudosReponse.Add(laudoDto);
        }

        return laudosReponse;
    }
}
