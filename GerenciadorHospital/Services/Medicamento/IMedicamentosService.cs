using GerenciadorHospital.Dto.Requests;
using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Medicamento
{
    public interface IMedicamentosService
    {
        public Task<List<MedicamentoPacienteModel>> BuscarTodosMedicamentosPaciente();
        public Task<MedicamentoPacienteModel> BuscarPorId(int id);
        public Task<MedicamentoPacienteModel> Adicionar(MedicamentoDto medicamentoDto);
        public Task<MedicamentoPacienteModel> Atualizar(MedicamentoDto medicamentoDto, int id);
        public Task<bool> Apagar(int id);
    }
}
