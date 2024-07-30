using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Convenio;

public class RemoverConvenioUseCase
{
    private readonly IConvenio _convenio;

    public RemoverConvenioUseCase(IConvenio convenio)
    {
        _convenio = convenio;
    }

    public async Task<bool> Executar(int id)
    {
        var convenioRemovido = await _convenio.Apagar(id);

        return convenioRemovido;
    }
}
