using GerenciadorHospital.Models;

namespace GerenciadorHospital.Repositorios.Interfaces
{
    public interface ILaudoRepositorio
    {
        Task<List<LaudoModel>> BuscarTodosLaudos();
        Task<LaudoModel> BuscarPorId(int id);
        Task<LaudoModel> Adicionar(LaudoModel laudo);
        Task<LaudoModel> Atualizar(LaudoModel laudo, int id);
        Task<bool> Apagar(int id);
    }
}
