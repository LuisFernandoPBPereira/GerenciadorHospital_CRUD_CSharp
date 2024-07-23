using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Convenio;

public class BuscarPorIdConvenioUseCase
{
    private readonly IConvenio _convenio;

    public BuscarPorIdConvenioUseCase(IConvenio convenio)
    {
        _convenio = convenio;
    }

    public async Task<ConvenioEntity> BuscarPorId(int id)
    {
        var convenioEntity = await _convenio.BuscarPorId(id);

        return convenioEntity;
    }
}
