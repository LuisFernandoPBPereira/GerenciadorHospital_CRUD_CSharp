using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Laudo
{
    public interface ILaudoService
    {
        public Task<List<LaudoModel>> BuscarTodosLaudos();
        public Task<LaudoModel> BuscarPorId(int id);
        public Task<FileContentResult> BuscarImagemLaudoPorId(int id);
        public Task<List<LaudoModel>> BuscarLaudo(string? dataInicial, string? dataFinal, int medicoId, int pacienteId);
        public Task<LaudoModel> Adicionar(LaudoModel laudoModel);
        public Task<LaudoModel> Atualizar(LaudoModel laudoModel, int id);
        public Task<bool> Apagar(int id);
    }
}
