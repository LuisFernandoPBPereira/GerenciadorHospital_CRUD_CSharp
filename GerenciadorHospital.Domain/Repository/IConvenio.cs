using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Domain.Repository;

public interface IConvenio
{
    Task<IEnumerable<ConvenioEntity>> BuscarTodos();
    Task<ConvenioEntity> BuscarPorId(int id);
    Task<ConvenioEntity> Adicionar(ConvenioEntity convenio);
    Task<ConvenioEntity> Atualizar(ConvenioEntity convenio);
    Task<bool> Apagar(int id);
}
