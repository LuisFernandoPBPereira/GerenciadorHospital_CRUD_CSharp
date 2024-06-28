using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Infraestructure.Repository;

public class PacienteRepository : IPaciente
{
    public Task<PacienteEntity> Adicionar(PacienteEntity paciente)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Apagar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PacienteEntity> Atualizar(PacienteEntity paciente)
    {
        throw new NotImplementedException();
    }

    public Task<PacienteEntity> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }
}
