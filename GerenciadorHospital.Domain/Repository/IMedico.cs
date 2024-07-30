using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Domain.Repository;

public interface IMedico
{
    Task<MedicoEntity> BuscarPorId(int id);
    Task<IEnumerable<MedicoEntity>> BuscarTodos();
    Task<MedicoEntity> Adicionar(MedicoEntity medico);
    Task<MedicoEntity> Atualizar(MedicoEntity medico);
    Task<bool> Apagar(int id);
}
