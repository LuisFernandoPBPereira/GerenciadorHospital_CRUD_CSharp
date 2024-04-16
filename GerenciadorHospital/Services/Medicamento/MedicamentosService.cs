using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;

namespace GerenciadorHospital.Services.Medicamento
{
    public class MedicamentosService : IMedicamentosService
    {
        private readonly IMedicamentosPacienteRepositorio _medicamentosPacienteRepositorio;
        public MedicamentosService(IMedicamentosPacienteRepositorio medicamentosPacienteRepositorio)
        {
            _medicamentosPacienteRepositorio = medicamentosPacienteRepositorio;
        }
        public async Task<MedicamentoPacienteModel> Adicionar(MedicamentoPacienteModel medicamentoModel)
        {
            MedicamentoPacienteModel medicamentos = await _medicamentosPacienteRepositorio.Adicionar(medicamentoModel);
            return medicamentos;
        }

        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _medicamentosPacienteRepositorio.Apagar(id);
            return apagado;
        }

        public async Task<MedicamentoPacienteModel> Atualizar(MedicamentoPacienteModel medicamentoModel, int id)
        {
            medicamentoModel.Id = id;
            MedicamentoPacienteModel medicamentos = await _medicamentosPacienteRepositorio.Atualizar(medicamentoModel, id);
            return medicamentos;
        }

        public async Task<MedicamentoPacienteModel> BuscarPorId(int id)
        {
            MedicamentoPacienteModel medicamentos = await _medicamentosPacienteRepositorio.BuscarPorId(id);
            return medicamentos;
        }

        public async Task<List<MedicamentoPacienteModel>> BuscarTodosMedicamentosPaciente()
        {
            List<MedicamentoPacienteModel> medicos = await _medicamentosPacienteRepositorio.BuscarTodosMedicamentosPaciente();
            return medicos;
        }
    }
}
