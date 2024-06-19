using GerenciadorHospital.Data;
using GerenciadorHospital.Data.ORM;
using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios.Convenio
{
    public class ConvenioRepositorio : IConvenioRepositorio
    {
        private readonly BancoContext _bancoContext;
        private readonly IRepositorioORM<ConvenioModel> _ormRepo;
        #region Construtor
        public ConvenioRepositorio(BancoContext bancoContext, IRepositorioORM<ConvenioModel> entityFramework)
        {
            _bancoContext = bancoContext;
            _ormRepo = entityFramework;
        }
        #endregion

        #region Repositório - Adicionar Convênio
        public async Task<ConvenioModel> Adicionar(ConvenioModel convenio)
        {
            await _ormRepo.AddAsync(convenio);
            await _ormRepo.SaveChangesAsync();

            return convenio;

        }
        #endregion

        #region Repositório - Apagar Convênio
        public async Task<bool> Apagar(int id)
        {
            ConvenioModel? convenioPorId = await BuscarPorId(id);
            if (convenioPorId == null)
                throw new Exception($"Convênio para o ID: {id} não foi encontrado no banco de dados.");

            _ormRepo.Delete(convenioPorId);
            await _ormRepo.SaveChangesAsync();

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

            _ormRepo.Update(convenioPorId);
            await _ormRepo.SaveChangesAsync();

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
