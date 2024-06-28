using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.ORM;
using GerenciadorHospital.Infraestructure.Mapper;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Repository;

public class LaudoRepository : ILaudo
{
    private readonly IRepositorioORM<LaudoModel> _repo;

    public LaudoRepository(IRepositorioORM<LaudoModel> repo)
    {
        _repo = repo;
    }

    public async Task<LaudoEntity> Adicionar(LaudoEntity laudo)
    {
        var laudoModel = LaudoMapper.ToModel(laudo);
        await _repo.AddAsync(laudoModel);
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
        var laudoModel = LaudoMapper.ToModel(laudo);
        await _repo.UpdateAsync(laudoModel);
        await _repo.SaveChangesAsync();

        return laudo;
    }

    public async Task<LaudoEntity> BuscarPorId(int id)
    {
        var laudo = await _repo.GetByIdAsync(id);
        var laudoEntity = LaudoMapper.ToDomain(laudo);
        
        return laudoEntity;
    }
}
