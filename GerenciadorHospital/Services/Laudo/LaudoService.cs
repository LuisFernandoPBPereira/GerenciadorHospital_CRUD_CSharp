using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;

namespace GerenciadorHospital.Services.Laudo
{
    public class LaudoService : ILaudoService
    {
        private readonly ILaudoRepositorio _laudoRepositorio;
        public LaudoService(ILaudoRepositorio laudoRepositorio)
        {
            _laudoRepositorio = laudoRepositorio;
        }
        public async Task<LaudoModel> Adicionar(LaudoModel laudoModel)
        {
            LaudoModel laudo = await _laudoRepositorio.Adicionar(laudoModel);
            return laudo;
        }

        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _laudoRepositorio.Apagar(id);
            return apagado;
        }

        public async Task<LaudoModel> Atualizar(LaudoModel laudoModel, int id)
        {
            laudoModel.Id = id;
            LaudoModel laudo = await _laudoRepositorio.Atualizar(laudoModel, id);
            return laudo;
        }

        public async Task<List<LaudoModel>> BuscarLaudo(string? dataInicial, string? dataFinal, int medicoId, int pacienteId)
        {
            dataInicial = dataInicial ?? string.Empty;
            dataFinal = dataFinal ?? string.Empty;
            List<LaudoModel> laudos = await _laudoRepositorio.BuscarLaudo(dataInicial, dataFinal, medicoId, pacienteId);
            return laudos;
        }

        public async Task<LaudoModel> BuscarPorId(int id)
        {
            LaudoModel laudos = await _laudoRepositorio.BuscarPorId(id);
            return laudos;
        }

        public async Task<List<LaudoModel>> BuscarTodosLaudos()
        {
            List<LaudoModel> laudos = await _laudoRepositorio.BuscarTodosLaudos();
            return laudos;
        }
    }
}
