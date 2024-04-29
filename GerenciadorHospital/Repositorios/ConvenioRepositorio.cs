using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios
{
    public class ConvenioRepositorio : IConvenioRepositorio
    {
        //Criamos uma variável de contexto
        private readonly BancoContext _bancoContext;
        #region Construtor
        //Iniciamos o construtor e injetamos o contexto do banco de dados
        public ConvenioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        #endregion

        #region Repositório - Adicionar Convênio
        public async Task<ConvenioModel> Adicionar(ConvenioModel convenio)
        {
            //Os dados recebidos são inseridos na tabela Convenios
            await _bancoContext.Convenios.AddAsync(convenio);
            await _bancoContext.SaveChangesAsync();

            return convenio;

        }
        #endregion

        #region Repositório - Apagar Convênio
        public async Task<bool> Apagar(int id)
        {
            //Pegamos um convênio por Id de forma assíncrona
            ConvenioModel? convenioPorId = await BuscarPorId(id);
            if (convenioPorId == null)
            {
                throw new Exception($"Convênio para o ID: {id} não foi encontrado no banco de dados.");
            }
            //Removemos da tabela Convenios e salvamos as alterações
            _bancoContext.Convenios.Remove(convenioPorId);
            await _bancoContext.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Repositório - Atualizar Convênio
        public async Task<ConvenioModel> Atualizar(ConvenioModel convenio, int id)
        {
            ConvenioModel? convenioPorId = await BuscarPorId(id);

            if (convenioPorId == null)
                throw new Exception($"Convênio para o ID: {id} não foi encontrado no banco de dados.");

            convenioPorId.Nome = convenio.Nome;
            convenioPorId.Preco = convenio.Preco;
            
            _bancoContext.Convenios.Update(convenioPorId);
            await _bancoContext.SaveChangesAsync();

            return convenioPorId;
        }
        #endregion

        #region Repositório - Buscar Convênio Por ID
        public async Task<ConvenioModel?> BuscarPorId(int id)
        {
            return await _bancoContext.Convenios.FirstOrDefaultAsync(x => x.Id == id);

        }
        #endregion

        #region Repositório - Buscar Todos Convênios
        public async Task<List<ConvenioModel>> BuscarTodosConvenios()
        {
            //Buscamos todos os Convenios
            return await _bancoContext.Convenios.ToListAsync();
        }
        #endregion
    }
}
