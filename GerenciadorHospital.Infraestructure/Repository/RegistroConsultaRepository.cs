using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.ORM;

namespace GerenciadorHospital.Infraestructure.Repository;

public class RegistroConsultaRepository : IRegistroConsulta
{
    private readonly IRepositorioORM<RegistroConsultaEntity> _repo;

    public RegistroConsultaRepository(IRepositorioORM<RegistroConsultaEntity> repo)
    {
        _repo = repo;
    }

    public async Task<RegistroConsultaEntity> Adicionar(RegistroConsultaEntity consulta)
    {
        await _repo.AddAsync(consulta);
        await _repo.SaveChangesAsync();

        return consulta;
    }

    public async Task<bool> Apagar(int id)
    {
        await _repo.DeleteAsync(id);
        await _repo.SaveChangesAsync();

        return true;
    }

    public async Task<RegistroConsultaEntity> Atualizar(RegistroConsultaEntity consulta)
    {
        await _repo.UpdateAsync(consulta);
        await _repo.SaveChangesAsync();

        return consulta;
    }

    public async Task<RegistroConsultaEntity> BuscarPorId(int id)
    {
        var consulta = await _repo.GetByIdAsync(id);

        return consulta;
    }
}
