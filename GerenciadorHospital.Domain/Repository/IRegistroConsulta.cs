using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Domain.Repository;

public interface IRegistroConsulta
{
    Task<RegistroConsultaEntity> BuscarPorId(int id);
    Task<RegistroConsultaEntity> Adicionar(RegistroConsultaEntity consulta);
    Task<RegistroConsultaEntity> Atualizar(RegistroConsultaEntity consulta);
    Task<bool> Apagar(int id);
}
