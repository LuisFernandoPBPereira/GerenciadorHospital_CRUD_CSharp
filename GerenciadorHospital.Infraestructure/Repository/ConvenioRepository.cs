using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Infraestructure.Repository;

public class ConvenioRepository : IConvenio
{
    public Task<ConvenioEntity> Adicionar(ConvenioEntity convenio)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Apagar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ConvenioEntity> Atualizar(ConvenioEntity convenio)
    {
        throw new NotImplementedException();
    }

    public Task<ConvenioEntity> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }
}
