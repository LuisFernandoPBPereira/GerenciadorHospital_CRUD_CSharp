using GerenciadorHospital.Models;

namespace GerenciadorHospital.Repositorios.Interfaces
{
    public interface ITipoExameRepositorio
    {
        Task<List<TipoExameModel>> BuscarTodosExames();
        Task<TipoExameModel?> BuscarPorId(int id);
        Task<TipoExameModel> Adicionar(TipoExameModel tipoExame);
        Task<TipoExameModel> Atualizar(TipoExameModel tipoExame, int id);
        Task<bool> Apagar(int id);
    }
}
