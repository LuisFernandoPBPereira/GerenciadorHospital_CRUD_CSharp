using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.ORM;

namespace GerenciadorHospital.Infraestructure.Repository;

public class PacienteRepository : IPaciente
{
    private readonly IRepositorioORM<PacienteEntity> _repo;

    public PacienteRepository(IRepositorioORM<PacienteEntity> repo)
    {
        _repo = repo;
    }

    public async Task<PacienteEntity> Adicionar(PacienteEntity paciente)
    {
        await _repo.AddAsync(paciente);
        await _repo.SaveChangesAsync();

        return paciente;
    }

    public async Task<bool> Apagar(int id)
    {
        await _repo.DeleteAsync(id);
        await _repo.SaveChangesAsync();
        
        return true;
    }

    public async Task<PacienteEntity> Atualizar(PacienteEntity paciente)
    {
        await _repo.UpdateAsync(paciente);
        await _repo.SaveChangesAsync();

        return paciente;
    }

    public Task<PacienteEntity> BuscarPorId(int id)
    {
        var paciente = _repo.GetByIdAsync(id);
        
        return paciente;
    }
}
