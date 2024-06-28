using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Domain.Repository;

public interface IPaciente
{
    Task<PacienteEntity> BuscarPorId(int id);
    Task<PacienteEntity> Adicionar(PacienteEntity paciente);
    Task<PacienteEntity> Atualizar(PacienteEntity paciente);
    Task<bool> Apagar(int id);
}
