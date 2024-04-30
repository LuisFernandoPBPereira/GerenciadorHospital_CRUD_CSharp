using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios.Exame
{
    public class TipoExameRepositorio : ITipoExameRepositorio
    {
        private readonly BancoContext _bancoContext;
        #region Construtor
        public TipoExameRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        #endregion

        #region Repositório - Adicionar Exame
        public async Task<TipoExameModel> Adicionar(TipoExameModel tipoExame)
        {
            await _bancoContext.TiposExames.AddAsync(tipoExame);
            await _bancoContext.SaveChangesAsync();

            return tipoExame;
        }
        #endregion

        #region Repositório - Apagar Exame
        public async Task<bool> Apagar(int id)
        {
            TipoExameModel? tipoExamePorId = await BuscarPorId(id);

            if (tipoExamePorId == null)
                throw new Exception($"Tipo de Exame para o ID: {id} não foi encontrado no banco de dados.");

            _bancoContext.TiposExames.Remove(tipoExamePorId);
            await _bancoContext.SaveChangesAsync();

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

            _bancoContext.TiposExames.Update(tipoExamePorId);
            await _bancoContext.SaveChangesAsync();

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
