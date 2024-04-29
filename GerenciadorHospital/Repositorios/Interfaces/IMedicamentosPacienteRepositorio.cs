using GerenciadorHospital.Models;

namespace GerenciadorHospital.Repositorios.Interfaces
{
    public interface IMedicamentosPacienteRepositorio
    {
        Task<List<MedicamentoPacienteModel>> BuscarTodosMedicamentosPaciente();
        Task<MedicamentoPacienteModel?> BuscarPorId(int id);
        Task<MedicamentoPacienteModel> Adicionar(MedicamentoPacienteModel medicamentoPaciente);
        Task<MedicamentoPacienteModel> Atualizar(MedicamentoPacienteModel medicamentoPaciente, int id);
        Task<bool> Apagar(int id);
    }
}
