using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Convenio;

public class BuscarTodosConveniosUseCase
{
    private readonly IConvenio _convenio;

    public BuscarTodosConveniosUseCase(IConvenio convenio)
    {
        _convenio = convenio;
    }

    public async Task<IEnumerable<ConvenioEntity>> Executar()
    {
        var convenios = await _convenio.BuscarTodos();

        return convenios;
    }
}
