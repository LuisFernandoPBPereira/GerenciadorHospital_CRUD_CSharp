using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Application.DTOs.Responses;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Exame;

public class ExamePorIdUseCase
{
    private readonly ITipoExame _exame;

    public ExamePorIdUseCase(ITipoExame exame)
    {
        _exame = exame;
    }

    public async Task<TipoExameResponseDto> Executar(int id)
    {
        var exameEntity = await _exame.BuscarPorId(id);
        var responseExame = new TipoExameResponseDto(exameEntity);

        return responseExame;
    }
}
