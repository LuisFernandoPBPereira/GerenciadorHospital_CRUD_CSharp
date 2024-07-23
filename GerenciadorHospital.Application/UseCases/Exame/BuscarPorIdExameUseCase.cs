using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Exame;

public class BuscarPorIdExameUseCase
{
    private readonly ITipoExame _exame;

    public BuscarPorIdExameUseCase(ITipoExame exame)
    {
        _exame = exame;
    }

    public async Task<TipoExameEntity> BuscaPorId(int id)
    {
        var exameEntity = await _exame.BuscarPorId(id);

        return exameEntity;
    }
}
