using GerenciadorHospital.Data;
using GerenciadorHospital.Data.ORM;
using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios.Medicamento
{
    public class MedicamentoPacienteRepositorio : IMedicamentosPacienteRepositorio
    {
        private readonly BancoContext _bancoContext;
        private readonly IRepositorioORM<MedicamentoPacienteModel> _ormRepo;
        #region Construtor
        public MedicamentoPacienteRepositorio(BancoContext bancoContext, IRepositorioORM<MedicamentoPacienteModel> ormRepo)
        {
            _bancoContext = bancoContext;
            _ormRepo = ormRepo;
        }
        #endregion

        #region Repositório - Adicionar Medicamento
        public async Task<MedicamentoPacienteModel> Adicionar(MedicamentoPacienteModel medicamento)
        {
            await _ormRepo.AddAsync(medicamento);
            await _ormRepo.SaveChangesAsync();

            return medicamento;
        }
        #endregion

        #region Repositório - Apagar Medicamento
        public async Task<bool> Apagar(int id)
        {
            MedicamentoPacienteModel? medicamentoPorId = await BuscarPorId(id);

            if (medicamentoPorId == null)
                throw new Exception($"Medicamento para o ID: {id} não foi encontrado no banco de dados.");

            _ormRepo.Delete(medicamentoPorId);
            await _ormRepo.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Repositório - Atualizar Medicamento
        public async Task<MedicamentoPacienteModel> Atualizar(MedicamentoPacienteModel medicamento, int id)
        {
            MedicamentoPacienteModel? medicamentoPorId = await BuscarPorId(id);

            if (medicamentoPorId == null)
                throw new Exception($"Medicamento para o ID: {id} não foi encontrado no banco de dados.");

            medicamentoPorId.Nome = medicamento.Nome;
            medicamentoPorId.Composicao = medicamento.Composicao;
            medicamentoPorId.DataFabricacao = medicamento.DataFabricacao;
            medicamentoPorId.DataValidade = medicamento.DataValidade;

            _ormRepo.Update(medicamentoPorId);
            await _ormRepo.SaveChangesAsync();

            return medicamentoPorId;
        }
        #endregion

        #region Repositório - Buscar Medicamento Por ID
        public async Task<MedicamentoPacienteModel?> BuscarPorId(int id)
        {
            return await _bancoContext.MedicamentosPaciente.FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Repositório - Buscar Todos Medicamentos
        public async Task<List<MedicamentoPacienteModel>> BuscarTodosMedicamentosPaciente()
        {
            return await _bancoContext.MedicamentosPaciente.ToListAsync();
        }
        #endregion
    }
}
