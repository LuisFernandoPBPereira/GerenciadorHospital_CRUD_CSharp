using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.ORM;
using GerenciadorHospital.Infraestructure.Mapper;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Repository;

public class PacienteRepository : IPaciente
{
    private readonly IRepositorioORM<PacienteModel> _repo;

    public PacienteRepository(IRepositorioORM<PacienteModel> repo)
    {
        _repo = repo;
    }

    public async Task<PacienteEntity> Adicionar(PacienteEntity paciente)
    {
        var pacienteModel = PacienteMapper.ToModel(paciente);
        await _repo.AddAsync(pacienteModel);
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
        var pacienteModel = PacienteMapper.ToModel(paciente);
        await _repo.UpdateAsync(pacienteModel);
        await _repo.SaveChangesAsync();

        return paciente;
    }

    public async Task<PacienteEntity> BuscarPorId(int id)
    {
        var paciente = await _repo.GetByIdAsync(id);
        var pacienteEntity = PacienteMapper.ToDomain(paciente);

        return pacienteEntity;
    }
}
