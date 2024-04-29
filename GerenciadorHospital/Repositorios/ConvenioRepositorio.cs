using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios
{
    public class ConvenioRepositorio : IConvenioRepositorio
    {
        private readonly BancoContext _bancoContext;
        #region Construtor
        public ConvenioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        #endregion

        #region Repositório - Adicionar Convênio
        public async Task<ConvenioModel> Adicionar(ConvenioModel convenio)
        {
            await _bancoContext.Convenios.AddAsync(convenio);
            await _bancoContext.SaveChangesAsync();

            return convenio;

        }
        #endregion

        #region Repositório - Apagar Convênio
        public async Task<bool> Apagar(int id)
        {
            ConvenioModel? convenioPorId = await BuscarPorId(id);
            if (convenioPorId == null)
                throw new Exception($"Convênio para o ID: {id} não foi encontrado no banco de dados.");
            
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
            return await _bancoContext.Convenios.ToListAsync();
        }
        #endregion
    }
}
