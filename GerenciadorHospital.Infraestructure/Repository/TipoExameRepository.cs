using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Infraestructure.Repository;

public class TipoExameRepository : ITipoExame
{
    public Task<TipoExameEntity> Adicionar(TipoExameEntity exame)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Apagar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TipoExameEntity> Atualizar(TipoExameEntity exame)
    {
        throw new NotImplementedException();
    }

    public Task<TipoExameEntity> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }
}
