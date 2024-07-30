using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Domain.Repository;

public interface ILaudo
{
    Task<LaudoEntity> BuscarPorId(int id);
    Task<IEnumerable<LaudoEntity>> BuscarTodos();
    Task<LaudoEntity> Adicionar(LaudoEntity laudo);
    Task<LaudoEntity> Atualizar(LaudoEntity laudo);
    Task<bool> Apagar(int id);
}
