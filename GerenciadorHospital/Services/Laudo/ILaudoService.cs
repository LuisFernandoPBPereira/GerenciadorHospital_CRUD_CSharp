using GerenciadorHospital.Dto.Requests;
using GerenciadorHospital.Dto.Responses;
using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Laudo
{
    public interface ILaudoService
    {
        public Task<List<LaudoResponseDto>> BuscarTodosLaudos();
        public Task<LaudoResponseDto?> BuscarPorIdDto(int id);
        public Task<LaudoModel?> BuscarPorId(int id);
        public Task<FileContentResult> BuscarImagemLaudoPorId(int id);
        public Task<List<LaudoResponseDto>> BuscarLaudo(string? dataInicial, string? dataFinal, int medicoId, int pacienteId);
        public Task<LaudoModel> Adicionar(LaudoDto laudoDto);
        public Task<LaudoModel> Atualizar(LaudoDto laudoDto, int id);
        public Task<bool> Apagar(int id);
    }
}
