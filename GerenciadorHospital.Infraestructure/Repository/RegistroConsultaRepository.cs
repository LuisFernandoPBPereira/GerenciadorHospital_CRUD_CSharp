using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Infraestructure.Repository;

public class RegistroConsultaRepository : IRegistroConsulta
{
    public Task<RegistroConsultaEntity> Adicionar(RegistroConsultaEntity consulta)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Apagar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<RegistroConsultaEntity> Atualizar(RegistroConsultaEntity consulta)
    {
        throw new NotImplementedException();
    }

    public Task<RegistroConsultaEntity> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }
}
