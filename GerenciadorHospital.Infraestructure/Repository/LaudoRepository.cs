using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Infraestructure.Repository;

public class LaudoRepository : ILaudo
{
    public Task<LaudoEntity> Adicionar(LaudoEntity laudo)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Apagar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<LaudoEntity> Atualizar(LaudoEntity laudo)
    {
        throw new NotImplementedException();
    }

    public Task<LaudoEntity> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }
}
