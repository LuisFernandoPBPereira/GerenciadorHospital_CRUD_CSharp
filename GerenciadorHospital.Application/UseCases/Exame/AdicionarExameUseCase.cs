using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Exame;

public class AdicionarExameUseCase
{
    private readonly ITipoExame _exame;

    public AdicionarExameUseCase(ITipoExame exame)
    {
        _exame = exame;
    }

    public async Task<TipoExameEntity> Adicionar(TipoExameRequestDto exameDto)
    {
        var exameEntity = new TipoExameEntity(exameDto.Nome, exameDto.PacienteId, exameDto.MedicoId);
        var exameAdicionado = await _exame.Adicionar(exameEntity);

        return exameAdicionado;
    }
}
