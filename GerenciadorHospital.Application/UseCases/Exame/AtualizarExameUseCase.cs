using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Exame;

public class AtualizarExameUseCase
{
    private readonly ITipoExame _exame;

    public AtualizarExameUseCase(ITipoExame exame)
    {
        _exame = exame;
    }

    public async Task<TipoExameEntity> Atualizar(TipoExameRequestDto exameDto)
    {
        var exameEntity = new TipoExameEntity(exameDto.Nome, exameDto.PacienteId, exameDto.MedicoId);
        var exameAtualizado = await _exame.Atualizar(exameEntity);

        return exameAtualizado;
    }
}
