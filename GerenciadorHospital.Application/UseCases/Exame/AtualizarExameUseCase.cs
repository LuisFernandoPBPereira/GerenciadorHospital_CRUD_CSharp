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

    public async Task<TipoExameEntity> Executar(int id, TipoExameRequestDto exameDto)
    {
        var exameEntity = new TipoExameEntity(id, exameDto.Nome, exameDto.PacienteId, exameDto.MedicoId);
        var exameAtualizado = await _exame.Atualizar(exameEntity);

        return exameAtualizado;
    }
}
