using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.ORM;

namespace GerenciadorHospital.Infraestructure.Repository;

public class LaudoRepository : ILaudo
{
    private readonly IRepositorioORM<LaudoEntity> _repo;

    public LaudoRepository(IRepositorioORM<LaudoEntity> repo)
    {
        _repo = repo;
    }

    public async Task<LaudoEntity> Adicionar(LaudoEntity laudo)
    {
        await _repo.AddAsync(laudo);
        await _repo.SaveChangesAsync();

        return laudo;
    }

    public async Task<bool> Apagar(int id)
    {
        await _repo.DeleteAsync(id);
        await _repo.SaveChangesAsync();

        return true;
    }

    public async Task<LaudoEntity> Atualizar(LaudoEntity laudo)
    {
        await _repo.UpdateAsync(laudo);
        await _repo.SaveChangesAsync();

        return laudo;
    }

    public async Task<LaudoEntity> BuscarPorId(int id)
    {
        var laudo = await _repo.GetByIdAsync(id);
        
        return laudo;
    }
}
