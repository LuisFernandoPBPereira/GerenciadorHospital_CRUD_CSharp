using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.ORM;
using GerenciadorHospital.Infraestructure.Mapper;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Repository;

public class MedicoRepository : IMedico
{
    private readonly IRepositorioORM<MedicoModel> _repo;

    public MedicoRepository(IRepositorioORM<MedicoModel> repo)
    {
        _repo = repo;
    }

    public async Task<MedicoEntity> Adicionar(MedicoEntity medico)
    {
        var medicoModel = MedicoMapper.ToModel(medico);
        await _repo.AddAsync(medicoModel);
        await _repo.SaveChangesAsync();

        return medico;
    }

    public async Task<bool> Apagar(int id)
    {
        await _repo.DeleteAsync(id);
        await _repo.SaveChangesAsync();

        return true;
    }

    public async Task<MedicoEntity> Atualizar(MedicoEntity medico)
    {
        var medicoModel = MedicoMapper.ToModel(medico);
        await _repo.UpdateAsync(medicoModel);
        await _repo.SaveChangesAsync();

        return medico;
    }

    public async Task<MedicoEntity> BuscarPorId(int id)
    {
        var medico = await _repo.GetByIdAsync(id);
        var medicoEntity = MedicoMapper.ToDomain(medico);

        return medicoEntity;
    }
}
