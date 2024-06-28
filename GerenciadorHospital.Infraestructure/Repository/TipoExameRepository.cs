using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.ORM;

namespace GerenciadorHospital.Infraestructure.Repository;

public class TipoExameRepository : ITipoExame
{
    private readonly IRepositorioORM<TipoExameEntity> _repo;

    public TipoExameRepository(IRepositorioORM<TipoExameEntity> repo)
    {
        _repo = repo;
    }

    public async Task<TipoExameEntity> Adicionar(TipoExameEntity exame)
    {
        await _repo.AddAsync(exame);
        await _repo.SaveChangesAsync();

        return exame;
    }

    public async Task<bool> Apagar(int id)
    {
        await _repo.DeleteAsync(id);
        await _repo.SaveChangesAsync();

        return true;
    }

    public async Task<TipoExameEntity> Atualizar(TipoExameEntity exame)
    {
        await _repo.UpdateAsync(exame);
        await _repo.SaveChangesAsync();

        return exame;
    }

    public Task<TipoExameEntity> BuscarPorId(int id)
    {
        var exame = _repo.GetByIdAsync(id);

        return exame;
    }
}
