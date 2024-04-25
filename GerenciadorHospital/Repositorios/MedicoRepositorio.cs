using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios
{
    public class MedicoRepositorio : IMedicoRepositorio
    {
        //Criamos o contexto do banco de dados
        private readonly BancoContext _bancoContext;
        #region Construtor
        //Injetamos o contexto no construtor
        public MedicoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        #endregion

        #region Repositório - Adicionar Médico
        public async Task<MedicoModel> Adicionar(MedicoModel medico)
        {
            //Adicionamos o médico na tabela Medicos e salvamos as alterações
            await _bancoContext.Medicos.AddAsync(medico);
            await _bancoContext.SaveChangesAsync();

            return medico;
        }
        #endregion

        #region Repositório - Apagar Médico
        public async Task<bool> Apagar(int id)
        {
            //Pegamos um médico por id de forma assíncrona
            MedicoModel medicoPorId = await BuscarPorId(id);
            if (medicoPorId == null)
            {
                throw new Exception($"Médico para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Removemos do banco de dados e salvamos as alterações
            _bancoContext.Medicos.Remove(medicoPorId);
            await _bancoContext.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Repositório - Atualizar Médico
        public async Task<MedicoModel> Atualizar(MedicoModel medico, int id)
        {
            //Pegamos um médico por id de forma assíncrona
            MedicoModel medicoPorId = await BuscarPorId(id);
            if (medicoPorId == null)
            {
                throw new Exception($"Médico para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Atualizamos os devidos campos
            medicoPorId.Nome = medico.Nome;
            medicoPorId.Cpf = medico.Cpf;
            medicoPorId.Crm = medico.Crm;
            medicoPorId.Endereco = medico.Endereco;
            medicoPorId.DataNasc = medico.DataNasc;
            medicoPorId.Senha = medico.Senha;
            medicoPorId.Especializacao = medico.Especializacao;
            medicoPorId.CaminhoDoc = medico.CaminhoDoc;

            //Atualizamos o banco de dados e salvamos as alterações
            _bancoContext.Medicos.Update(medicoPorId);
            await _bancoContext.SaveChangesAsync();

            return medicoPorId;
        }

        #endregion

        #region Repositório - Buscar Documento do Médico Por ID
        public async Task<MedicoModel> BuscarDocMedicoPorId(int id)
        {
            return await _bancoContext.Medicos
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Repositório - Buscar Médico Por ID
        public async Task<MedicoModel> BuscarPorId(int id)
        {
            //Retornamos o primeiro médico ou o padrão por ID
            return await _bancoContext.Medicos.FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Repositório - Buscar Todos Médicos
        public async Task<List<MedicoModel>> BuscarTodosMedicos()
        {
            //Retornamos todos os médicos
            return await _bancoContext.Medicos.ToListAsync();
        }
        #endregion
    }
}
