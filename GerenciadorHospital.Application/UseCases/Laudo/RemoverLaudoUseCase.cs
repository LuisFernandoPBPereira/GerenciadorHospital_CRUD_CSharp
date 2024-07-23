using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Laudo;

public class RemoverLaudoUseCase
{
    private readonly ILaudo _laudo;

    public RemoverLaudoUseCase(ILaudo laudo)
    {
        _laudo = laudo;
    }

    public async Task<bool> Remover(int id)
    {
        var laudoRemovido = await _laudo.Apagar(id);

        return laudoRemovido;
    }
}
