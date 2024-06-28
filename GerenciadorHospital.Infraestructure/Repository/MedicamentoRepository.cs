using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.ORM;
using GerenciadorHospital.Infraestructure.Mapper;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Repository;

public class MedicamentoRepository : IMedicamento
{
    private readonly IRepositorioORM<MedicamentoPacienteModel> _repo;

    public MedicamentoRepository(IRepositorioORM<MedicamentoPacienteModel> repo)
    {
        _repo = repo;
    }

    public async Task<MedicamentoEntity> Adicionar(MedicamentoEntity medicamento)
    {
        var medicamentoModel = MedicamentoMapper.ToModel(medicamento);
        await _repo.AddAsync(medicamentoModel);
        await _repo.SaveChangesAsync();
        
        return medicamento;
    }

    public async Task<bool> Apagar(int id)
    {
        await _repo.DeleteAsync(id);
        await _repo.SaveChangesAsync();

        return true;
    }

    public async Task<MedicamentoEntity> Atualizar(MedicamentoEntity medicamento)
    {
        var medicamentoModel = MedicamentoMapper.ToModel(medicamento);
        await _repo.UpdateAsync(medicamentoModel);
        await _repo.SaveChangesAsync();

        return medicamento;
    }

    public async Task<MedicamentoEntity> BuscarPorId(int id)
    {
        var medicamento = await _repo.GetByIdAsync(id);
        var medicamentoEntity = MedicamentoMapper.ToDomain(medicamento);
        
        return medicamentoEntity;
    }
}
