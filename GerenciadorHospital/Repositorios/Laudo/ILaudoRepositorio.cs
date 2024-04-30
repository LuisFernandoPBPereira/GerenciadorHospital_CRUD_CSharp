using GerenciadorHospital.Models;

namespace GerenciadorHospital.Repositorios.Laudo
{
    public interface ILaudoRepositorio
    {
        Task<List<LaudoModel>> BuscarTodosLaudos();
        Task<LaudoModel?> BuscarPorId(int id);
        Task<LaudoModel?> BuscarImagemLaudoPorId(int id);
        Task<List<LaudoModel>> BuscarLaudo(string? dataInicial, string? dataFinal, int medicoId, int pacienteId);
        Task<LaudoModel> Adicionar(LaudoModel laudo);
        Task<LaudoModel> Atualizar(LaudoModel laudo, int id);
        Task<bool> Apagar(int id);
    }
}
