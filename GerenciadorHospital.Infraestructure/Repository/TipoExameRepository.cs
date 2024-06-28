using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.ORM;
using GerenciadorHospital.Infraestructure.Mapper;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Repository;

public class TipoExameRepository : ITipoExame
{
    private readonly IRepositorioORM<TipoExameModel> _repo;

    public TipoExameRepository(IRepositorioORM<TipoExameModel> repo)
    {
        _repo = repo;
    }

    public async Task<TipoExameEntity> Adicionar(TipoExameEntity exame)
    {
        var exameModel = ExameMapper.ToModel(exame);
        await _repo.AddAsync(exameModel);
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
        var exameModel = ExameMapper.ToModel(exame);
        await _repo.UpdateAsync(exameModel);
        await _repo.SaveChangesAsync();

        return exame;
    }

    public async Task<TipoExameEntity> BuscarPorId(int id)
    {
        var exame = await _repo.GetByIdAsync(id);
        var exameEntity = ExameMapper.ToDomain(exame);

        return exameEntity;
    }
}
