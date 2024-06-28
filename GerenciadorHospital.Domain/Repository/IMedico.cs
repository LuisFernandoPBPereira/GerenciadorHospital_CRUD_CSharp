using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Domain.Repository;

public interface IMedico
{
    Task<MedicoEntity> BuscarPorId(int id);
    Task<MedicoEntity> Adicionar(MedicoEntity medico);
    Task<MedicoEntity> Atualizar(MedicoEntity medico);
    Task<bool> Apagar(int id);
}
