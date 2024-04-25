using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios
{
    public class MedicamentoPacienteRepositorio : IMedicamentosPacienteRepositorio
    {
        //Criamos a variável de contexto do banco de dados
        private readonly BancoContext _bancoContext;
        #region Construtor
        //Injetamos o contexto no construtor
        public MedicamentoPacienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        #endregion

        #region Repositório - Adicionar Medicamento
        public async Task<MedicamentoPacienteModel> Adicionar(MedicamentoPacienteModel medicamento)
        {
            //Adicionamos o medicamento do paciente e salvamos as alterações
            await _bancoContext.MedicamentosPaciente.AddAsync(medicamento);
            await _bancoContext.SaveChangesAsync();

            return medicamento;
        }
        #endregion

        #region Repositório - Apagar Medicamento
        public async Task<bool> Apagar(int id)
        {
            //Pegamos um medicamento por ID de forma assíncrona
            MedicamentoPacienteModel medicamentoPorId = await BuscarPorId(id);
            if (medicamentoPorId == null)
            {
                throw new Exception($"Medicamento para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Removemos do banco de dados e salvamos as alterações
            _bancoContext.MedicamentosPaciente.Remove(medicamentoPorId);
            await _bancoContext.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Repositório - Atualizar Medicamento
        public async Task<MedicamentoPacienteModel> Atualizar(MedicamentoPacienteModel medicamento, int id)
        {
            //Pegamos um medicamento por ID de forma assíncrona
            MedicamentoPacienteModel medicamentoPorId = await BuscarPorId(id);
            if (medicamentoPorId == null)
            {
                throw new Exception($"Medicamento para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Atualizamos os devidos campos
            medicamentoPorId.Nome = medicamento.Nome;
            medicamentoPorId.Composicao = medicamento.Composicao;
            medicamentoPorId.DataFabricacao = medicamento.DataFabricacao;
            medicamentoPorId.DataValidade = medicamento.DataValidade;

            //Atualizamos no banco de dados e salvamos as alterações
            _bancoContext.MedicamentosPaciente.Update(medicamentoPorId);
            await _bancoContext.SaveChangesAsync();

            return medicamentoPorId;
        }
        #endregion

        #region Repositório - Buscar Medicamento Por ID
        public async Task<MedicamentoPacienteModel> BuscarPorId(int id)
        {
            //Retornamos o primeiro medicamento ou o padrão pelo ID
            return await _bancoContext.MedicamentosPaciente.FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Repositório - Buscar Todos Medicamentos
        public async Task<List<MedicamentoPacienteModel>> BuscarTodosMedicamentosPaciente()
        {
            //Retornamos todos os medicamentos
            return await _bancoContext.MedicamentosPaciente.ToListAsync();
        }
        #endregion
    }
}
