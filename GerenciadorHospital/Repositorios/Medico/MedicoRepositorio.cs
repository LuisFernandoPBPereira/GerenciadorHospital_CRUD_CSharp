using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios.Medico
{
    public class MedicoRepositorio : IMedicoRepositorio
    {
        private readonly BancoContext _bancoContext;
        #region Construtor
        public MedicoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        #endregion

        #region Repositório - Adicionar Médico
        public async Task<MedicoModel> Adicionar(MedicoModel medico)
        {
            await _bancoContext.Medicos.AddAsync(medico);
            await _bancoContext.SaveChangesAsync();

            return medico;
        }
        #endregion

        #region Repositório - Apagar Médico
        public async Task<bool> Apagar(int id)
        {
            MedicoModel? medicoPorId = await BuscarPorId(id);

            if (medicoPorId == null)
                throw new Exception($"Médico para o ID: {id} não foi encontrado no banco de dados.");

            _bancoContext.Medicos.Remove(medicoPorId);
            await _bancoContext.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Repositório - Atualizar Médico
        public async Task<MedicoModel> Atualizar(MedicoModel medico, int id)
        {
            MedicoModel? medicoPorId = await BuscarPorId(id);

            if (medicoPorId == null)
                throw new Exception($"Médico para o ID: {id} não foi encontrado no banco de dados.");

            medicoPorId.Nome = medico.Nome;
            medicoPorId.Cpf = medico.Cpf;
            medicoPorId.Crm = medico.Crm;
            medicoPorId.Endereco = medico.Endereco;
            medicoPorId.DataNasc = medico.DataNasc;
            medicoPorId.Senha = medico.Senha;
            medicoPorId.Especializacao = medico.Especializacao;
            medicoPorId.CaminhoDoc = medico.CaminhoDoc;

            _bancoContext.Medicos.Update(medicoPorId);
            await _bancoContext.SaveChangesAsync();

            return medicoPorId;
        }

        #endregion

        #region Repositório - Buscar Documento do Médico Por ID
        public async Task<MedicoModel?> BuscarDocMedicoPorId(int id)
        {
            return await _bancoContext.Medicos
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Repositório - Buscar Médico Por ID
        public async Task<MedicoModel?> BuscarPorId(int id)
        {
            return await _bancoContext.Medicos.FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Repositório - Buscar Todos Médicos
        public async Task<List<MedicoModel>> BuscarTodosMedicos()
        {
            return await _bancoContext.Medicos.ToListAsync();
        }
        #endregion
    }
}
