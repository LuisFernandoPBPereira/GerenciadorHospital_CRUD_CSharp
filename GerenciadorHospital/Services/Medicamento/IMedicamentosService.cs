using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Medicamento
{
    public interface IMedicamentosService
    {
        public Task<List<MedicamentoPacienteModel>> BuscarTodosMedicamentosPaciente();
        public Task<MedicamentoPacienteModel> BuscarPorId(int id);
        public Task<MedicamentoPacienteModel> Adicionar( MedicamentoPacienteModel medicamentoModel);
        public Task<MedicamentoPacienteModel> Atualizar( MedicamentoPacienteModel medicamentoModel, int id);
        public Task<bool> Apagar(int id);
    }
}
