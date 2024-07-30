using GerenciadorHospital.Application.DTOs.Responses;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Exame;

public class TodosExamesUseCase
{
    private readonly ITipoExame _exame;

    public TodosExamesUseCase(ITipoExame exame)
    {
        _exame = exame;
    }

    public async Task<IEnumerable<TipoExameResponseDto>> Executar()
    {
        var exames = await _exame.BuscarTodos();
        var examesDto = new List<TipoExameResponseDto>();

        foreach (var exame in exames)
        {
            var responseExame = new TipoExameResponseDto(exame);
            examesDto.Add(responseExame);
        }

        return examesDto;
    }
}
