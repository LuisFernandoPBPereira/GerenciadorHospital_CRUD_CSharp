using GerenciadorHospital.Models;

namespace GerenciadorHospital.Repositorios.Interfaces
{
    public interface IPacienteRepositorio
    {
        Task<List<PacienteModel>> BuscarTodosPacientes();
        Task<PacienteModel?> BuscarPorId(int id);
        Task<PacienteModel?> BuscarDocConvenioPorId(int id);
        Task<PacienteModel?> BuscarDocPorId(int id);
        Task<PacienteModel> Adicionar(PacienteModel paciente);
        Task<PacienteModel> Atualizar(PacienteModel paciente, int id);
        Task<bool> Apagar(int id);
    }
}
