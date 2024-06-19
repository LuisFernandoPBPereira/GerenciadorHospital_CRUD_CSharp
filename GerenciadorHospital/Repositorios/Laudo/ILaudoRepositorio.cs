using GerenciadorHospital.Dto.Responses;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Repositorios.Laudo
{
    public interface ILaudoRepositorio
    {
        Task<List<LaudoResponseDto>> BuscarTodosLaudos();
        Task<LaudoModel?> BuscarPorId(int id);
        Task<LaudoResponseDto?> BuscarPorIdDto(int id);
        Task<LaudoModel?> BuscarImagemLaudoPorId(int id);
        Task<List<LaudoResponseDto>> BuscarLaudo(string? dataInicial, string? dataFinal, int medicoId, int pacienteId);
        Task<LaudoModel> Adicionar(LaudoModel laudo);
        Task<LaudoModel> Atualizar(LaudoModel laudo, int id);
        Task<bool> Apagar(int id);
    }
}
