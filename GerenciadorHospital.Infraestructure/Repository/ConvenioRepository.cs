using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.ORM;

namespace GerenciadorHospital.Infraestructure.Repository;

public class ConvenioRepository : IConvenio
{
    private readonly IRepositorioORM<ConvenioEntity> _repo;
    public ConvenioRepository(IRepositorioORM<ConvenioEntity> repo)
    {
        _repo = repo;
    }
    public async Task<ConvenioEntity> Adicionar(ConvenioEntity convenio)
    {
        await _repo.AddAsync(convenio);
        await _repo.SaveChangesAsync();

        return convenio;
    }

    public async Task<bool> Apagar(int id)
    {
        await _repo.DeleteAsync(id);
        await _repo.SaveChangesAsync();

        return true;
    }

    public async Task<ConvenioEntity> Atualizar(ConvenioEntity convenio)
    {
        await _repo.UpdateAsync(convenio);
        await _repo.SaveChangesAsync();

        return convenio;
    }

    public async Task<ConvenioEntity> BuscarPorId(int id)
    {
        var convenio = await _repo.GetByIdAsync(id);
        
        return convenio;
    }
}
