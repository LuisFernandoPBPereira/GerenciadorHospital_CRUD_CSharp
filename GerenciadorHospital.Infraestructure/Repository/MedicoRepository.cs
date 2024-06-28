using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Infraestructure.Repository;

public class MedicoRepository : IMedico
{
    public Task<MedicoEntity> Adicionar(MedicoEntity medico)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Apagar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<MedicoEntity> Atualizar(MedicoEntity medico)
    {
        throw new NotImplementedException();
    }

    public Task<MedicoEntity> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }
}
