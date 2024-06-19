using GerenciadorHospital.Data;
using GerenciadorHospital.Data.ORM;
using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios.Exame
{
    public class TipoExameRepositorio : ITipoExameRepositorio
    {
        private readonly BancoContext _bancoContext;
        private readonly IRepositorioORM<TipoExameModel> _ormRepo;
        #region Construtor
        public TipoExameRepositorio(BancoContext bancoContext, IRepositorioORM<TipoExameModel> entityFramework)
        {
            _bancoContext = bancoContext;
            _ormRepo = entityFramework;
        }
        #endregion

        #region Repositório - Adicionar Exame
        public async Task<TipoExameModel> Adicionar(TipoExameModel tipoExame)
        {
            await _ormRepo.AddAsync(tipoExame);
            await _ormRepo.SaveChangesAsync();

            return tipoExame;
        }
        #endregion

        #region Repositório - Apagar Exame
        public async Task<bool> Apagar(int id)
        {
            TipoExameModel? tipoExamePorId = await BuscarPorId(id);

            if (tipoExamePorId == null)
                throw new Exception($"Tipo de Exame para o ID: {id} não foi encontrado no banco de dados.");

            await _ormRepo.Delete(tipoExamePorId);
            await _ormRepo.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Repositório - Atualizar Exame
        public async Task<TipoExameModel> Atualizar(TipoExameModel tipoExame, int id)
        {
            TipoExameModel? tipoExamePorId = await BuscarPorId(id);

            if (tipoExamePorId == null)
                throw new Exception($"Tipo de Exame para o ID: {id} não foi encontrado no banco de dados.");

            tipoExamePorId.Nome = tipoExame.Nome;
            tipoExamePorId.PacienteId = tipoExame.PacienteId;
            tipoExamePorId.MedicoId = tipoExame.MedicoId;

            await _ormRepo.Update(tipoExamePorId);
            await _ormRepo.SaveChangesAsync();

            return tipoExamePorId;
        }
        #endregion

        #region Repositório - Buscar Exame Por ID
        public async Task<TipoExameModel?> BuscarPorId(int id)
        {
            return await _bancoContext.TiposExames.FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Repositório - Buscar Todos Exames
        public async Task<List<TipoExameModel>> BuscarTodosExames()
        {
            return await _bancoContext.TiposExames.ToListAsync();
        }
        #endregion
    }
}
