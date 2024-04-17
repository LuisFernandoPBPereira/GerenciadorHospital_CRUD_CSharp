using GerenciadorHospital.Controllers;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;

namespace GerenciadorHospital.Services.Laudo
{
    public class LaudoService : ILaudoService
    {
        private readonly ILaudoRepositorio _laudoRepositorio;
        private readonly ILogger<LaudoController> _logger;
        public LaudoService(ILaudoRepositorio laudoRepositorio,
                            ILogger<LaudoController> logger)
        {
            _laudoRepositorio = laudoRepositorio;
            _logger = logger;
            _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Os valores foram atribuídos no construtor da Service");
        }
        public async Task<LaudoModel> Adicionar(LaudoModel laudoModel)
        {
            LaudoModel laudo = await _laudoRepositorio.Adicionar(laudoModel);

            if (laudo is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Cadastro do laudo foi realizado.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Laudo)}: Cadastro do laudo não foi concluído.");

            return laudo;
        }

        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _laudoRepositorio.Apagar(id);

            if (apagado)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Remoção do laudo foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Laudo)}: Remoção do laudo não foi realizada.");

            return apagado;
        }

        public async Task<LaudoModel> Atualizar(LaudoModel laudoModel, int id)
        {
            laudoModel.Id = id;
            LaudoModel laudo = await _laudoRepositorio.Atualizar(laudoModel, id);

            if (laudo is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Atualização do laudo foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Laudo)}: Atualização do laudo não foi realizada.");

            return laudo;
        }

        public async Task<List<LaudoModel>> BuscarLaudo(string? dataInicial, string? dataFinal, int medicoId, int pacienteId)
        {
            dataInicial = dataInicial ?? string.Empty;
            dataFinal = dataFinal ?? string.Empty;
            List<LaudoModel> laudos = await _laudoRepositorio.BuscarLaudo(dataInicial, dataFinal, medicoId, pacienteId);

            if (laudos is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Busca do laudo foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Laudo)}: Busca do laudo não foi realizada.");

            return laudos;
        }

        public async Task<LaudoModel> BuscarPorId(int id)
        {
            LaudoModel laudo = await _laudoRepositorio.BuscarPorId(id);

            if (laudo is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Busca do laudo com o ID: {id} foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Laudo)}: Busca do laudo com o ID: {id} não foi realizada.");

            return laudo;
        }

        public async Task<List<LaudoModel>> BuscarTodosLaudos()
        {
            List<LaudoModel> laudos = await _laudoRepositorio.BuscarTodosLaudos();

            if (laudos is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Busca de todos os laudos foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Laudo)}: Busca de todos os laudo não foi realizada.");

            return laudos;
        }
    }
}
