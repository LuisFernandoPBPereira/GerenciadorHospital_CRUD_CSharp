using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.ORM;

namespace GerenciadorHospital.Infraestructure.Repository;

public class MedicamentoRepository : IMedicamento
{
    private readonly IRepositorioORM<MedicamentoEntity> _repo;

    public MedicamentoRepository(IRepositorioORM<MedicamentoEntity> repo)
    {
        _repo = repo;
    }

    public async Task<MedicamentoEntity> Adicionar(MedicamentoEntity convenio)
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

    public async Task<MedicamentoEntity> Atualizar(MedicamentoEntity convenio)
    {
        await _repo.UpdateAsync(convenio);
        await _repo.SaveChangesAsync();

        return convenio;
    }

    public async Task<MedicamentoEntity> BuscarPorId(int id)
    {
        var medicamento = await _repo.GetByIdAsync(id);
        
        return medicamento;
    }
}
