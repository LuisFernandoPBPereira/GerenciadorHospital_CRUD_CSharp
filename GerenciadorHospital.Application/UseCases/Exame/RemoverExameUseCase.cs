using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Exame;

public class RemoverExameUseCase
{
    private readonly ITipoExame _exame;

    public RemoverExameUseCase(ITipoExame exame)
    {
        _exame = exame;
    }

    public async Task<bool> Remover(int id)
    {
        var exameApagado = await _exame.Apagar(id);

        return exameApagado;
    }
}
