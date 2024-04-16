using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Exame
{
    public interface ITipoExameService
    {
        public Task<List<TipoExameModel>> BuscarTodosExames();
        public Task<TipoExameModel> BuscarPorId(int id);
        public Task<TipoExameModel> Adicionar(TipoExameModel tipoExameModel);
        public Task<TipoExameModel> Atualizar(TipoExameModel tipoExameModel, int id);
        public Task<bool> Apagar(int id);
    }
}
