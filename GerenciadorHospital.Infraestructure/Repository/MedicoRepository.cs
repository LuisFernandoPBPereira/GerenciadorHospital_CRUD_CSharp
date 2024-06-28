using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.ORM;

namespace GerenciadorHospital.Infraestructure.Repository;

public class MedicoRepository : IMedico
{
    private readonly IRepositorioORM<MedicoEntity> _repo;

    public MedicoRepository(IRepositorioORM<MedicoEntity> repo)
    {
        _repo = repo;
    }

    public async Task<MedicoEntity> Adicionar(MedicoEntity medico)
    {
        await _repo.AddAsync(medico);
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
        await _repo.UpdateAsync(medico);
        await _repo.SaveChangesAsync();

        return medico;
    }

    public async Task<MedicoEntity> BuscarPorId(int id)
    {
        var medico = await _repo.GetByIdAsync(id);

        return medico;
    }
}
