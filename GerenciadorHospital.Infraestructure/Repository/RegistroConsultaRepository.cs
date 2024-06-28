using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.ORM;
using GerenciadorHospital.Infraestructure.Mapper;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Repository;

public class RegistroConsultaRepository : IRegistroConsulta
{
    private readonly IRepositorioORM<RegistroConsultaModel> _repo;

    public RegistroConsultaRepository(IRepositorioORM<RegistroConsultaModel> repo)
    {
        _repo = repo;
    }

    public async Task<RegistroConsultaEntity> Adicionar(RegistroConsultaEntity consulta)
    {
        var consultaModel = ConsultaMapper.ToModel(consulta);
        await _repo.AddAsync(consultaModel);
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
        var consultaModel = ConsultaMapper.ToModel(consulta);
        await _repo.UpdateAsync(consultaModel);
        await _repo.SaveChangesAsync();

        return consulta;
    }

    public async Task<RegistroConsultaEntity> BuscarPorId(int id)
    {
        var consulta = await _repo.GetByIdAsync(id);
        var consultaEntity = ConsultaMapper.ToDomain(consulta);

        return consultaEntity;
    }
}
