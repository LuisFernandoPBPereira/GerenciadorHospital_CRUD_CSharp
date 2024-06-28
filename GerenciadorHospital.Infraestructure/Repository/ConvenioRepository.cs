using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.ORM;
using GerenciadorHospital.Infraestructure.Mapper;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Repository;

public class ConvenioRepository : IConvenio
{
    private readonly IRepositorioORM<ConvenioModel> _repo;
    public ConvenioRepository(IRepositorioORM<ConvenioModel> repo)
    {
        _repo = repo;
    }
    public async Task<ConvenioEntity> Adicionar(ConvenioEntity convenio)
    {
        var convenioModel = ConvenioMapper.ToModel(convenio);
        await _repo.AddAsync(convenioModel);
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
        var convenioModel = ConvenioMapper.ToModel(convenio);
        await _repo.UpdateAsync(convenioModel);
        await _repo.SaveChangesAsync();

        return convenio;
    }

    public async Task<ConvenioEntity> BuscarPorId(int id)
    {
        var convenio = await _repo.GetByIdAsync(id);
        var convenioEntity = ConvenioMapper.ToDomain(convenio);

        return convenioEntity;
    }
}
