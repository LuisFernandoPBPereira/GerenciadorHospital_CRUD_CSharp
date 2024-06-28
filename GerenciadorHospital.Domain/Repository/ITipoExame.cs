using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Domain.Repository;

public interface ITipoExame
{
    Task<TipoExameEntity> BuscarPorId(int id);
    Task<TipoExameEntity> Adicionar(TipoExameEntity exame);
    Task<TipoExameEntity> Atualizar(TipoExameEntity exame);
    Task<bool> Apagar(int id);
}
