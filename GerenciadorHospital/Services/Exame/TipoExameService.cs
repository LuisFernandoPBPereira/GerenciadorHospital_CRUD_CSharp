using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;

namespace GerenciadorHospital.Services.Exame
{
    public class TipoExameService : ITipoExameService
    {
        private readonly ITipoExameRepositorio _tipoExameRepositorio;
        public TipoExameService(ITipoExameRepositorio tipoExameRepositorio)
        {
            _tipoExameRepositorio = tipoExameRepositorio;
        }
        public async Task<TipoExameModel> Adicionar(TipoExameModel tipoExameModel)
        {
            TipoExameModel exame = await _tipoExameRepositorio.Adicionar(tipoExameModel);
            return exame;
        }

        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _tipoExameRepositorio.Apagar(id);
            return apagado;
        }

        public async Task<TipoExameModel> Atualizar(TipoExameModel tipoExameModel, int id)
        {
            tipoExameModel.Id = id;
            TipoExameModel exame = await _tipoExameRepositorio.Atualizar(tipoExameModel, id);
            return exame;
        }

        public async Task<TipoExameModel> BuscarPorId(int id)
        {
            TipoExameModel exames = await _tipoExameRepositorio.BuscarPorId(id);
            return exames;
        }

        public async Task<List<TipoExameModel>> BuscarTodosExames()
        {
            List<TipoExameModel> exames = await _tipoExameRepositorio.BuscarTodosExames();
            return exames;
        }
    }
}
