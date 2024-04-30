using GerenciadorHospital.Models;

namespace GerenciadorHospital.Repositorios.Convenio
{
    public interface IConvenioRepositorio
    {
        Task<List<ConvenioModel>> BuscarTodosConvenios();
        Task<ConvenioModel?> BuscarPorId(int id);
        Task<ConvenioModel> Adicionar(ConvenioModel convenio);
        Task<ConvenioModel> Atualizar(ConvenioModel convenio, int id);
        Task<bool> Apagar(int id);
    }
}
