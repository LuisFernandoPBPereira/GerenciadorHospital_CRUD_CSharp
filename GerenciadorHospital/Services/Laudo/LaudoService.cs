using GerenciadorHospital.Controllers;
using GerenciadorHospital.Dto.Requests;
using GerenciadorHospital.Dto.Responses;
using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Laudo;
using GerenciadorHospital.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Laudo
{
    public class LaudoService : ILaudoService
    {
        private readonly ILaudoRepositorio _laudoRepositorio;
        private readonly ILogger<LaudoController> _logger;
        MensagensLog mensagensLog = new MensagensLog();

        #region Construtor
        public LaudoService(ILaudoRepositorio laudoRepositorio,
                            ILogger<LaudoController> logger)
        {
            _laudoRepositorio = laudoRepositorio;
            _logger = logger;
            _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Os valores foram atribuídos no construtor da Service");
        }
        #endregion

        #region Service - Adicionar Laudo
        public async Task<LaudoModel> Adicionar(LaudoDto laudoDto)
        {
            LaudoModel laudoModel = new LaudoModel(laudoDto);
            ValidaLaudo validaLaudo = new ValidaLaudo(laudoModel);
            validaLaudo.ValidacaoLaudo();

            if (validaLaudo.ValidaImagem())
            {
                LaudoModel laudo = await _laudoRepositorio.Adicionar(laudoModel);

                if (laudo is not null)
                    _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Cadastro do laudo foi realizado.");
                else
                    _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_POST_Laudo)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_POST_Laudo)}");

                return laudo ?? throw new Exception("Não foi possível cadastrar o laudo, a response foi nula");
            }

            throw new Exception("Não foi possível validar o laudo, a imagem não é válida");

        }
        #endregion

        #region Service - Apagar Laudo
        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _laudoRepositorio.Apagar(id);

            if (apagado)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Remoção do laudo foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_DEL_Laudo)}:  {mensagensLog.ExibirMensagem(CodigosLogErro.E_DEL_Laudo)}");

            return apagado;
        }
        #endregion

        #region Service - Atualizar Laudo
        public async Task<LaudoModel> Atualizar(LaudoDto laudoDto, int id)
        {
            LaudoModel laudoModel = new LaudoModel(laudoDto);
            ValidaLaudo validaLaudo = new ValidaLaudo(laudoModel);

            validaLaudo.ValidacaoLaudo();
            var laudoValidado = validaLaudo.ValidaImagem();

            if (laudoValidado == false)
                throw new Exception("Não foi possível carregar a imagem");

            LaudoModel laudo = await _laudoRepositorio.Atualizar(laudoModel, id);

            if (laudo is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Atualização do laudo foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_PUT_Laudo)}:  {mensagensLog.ExibirMensagem(CodigosLogErro.E_PUT_Laudo)}");

            return laudo ?? throw new Exception("Não foi possível atualizar o laudo, a response foi nula");
        }
        #endregion

        #region Service - Buscar Imagem do Laudo Por ID
        public async Task<FileContentResult> BuscarImagemLaudoPorId(int id)
        {
            LaudoModel? laudo = await _laudoRepositorio.BuscarImagemLaudoPorId(id);
            ValidaLaudo validaLaudo = new ValidaLaudo(laudo!);

            string caminho = laudo!.CaminhoImagemLaudo ?? string.Empty;
            var imagem = validaLaudo.BuscarImagemLaudo(caminho);

            if (imagem is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Busca do documento do convênio com ID: {id}, foi realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Laudo)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Laudo)} ->
                                        Busca da imagem do laudo com ID: {id}, não foi realizada.");

            return validaLaudo.BuscarImagemLaudo(caminho);
        }
        #endregion

        #region Service - Buscar Laudo com Filtro
        public async Task<List<LaudoResponseDto>> BuscarLaudo(string? dataInicial, string? dataFinal, int medicoId, int pacienteId)
        {
            dataInicial = dataInicial ?? string.Empty;
            dataFinal = dataFinal ?? string.Empty;
            List<LaudoResponseDto> laudos = await _laudoRepositorio.BuscarLaudo(dataInicial, dataFinal, medicoId, pacienteId);

            if (laudos is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Busca do laudo foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_GET_Laudo)}:  {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Laudo)}");

            return laudos ?? throw new Exception("Não foi possível buscar o laudo, a busca retornou nulo");
        }
        #endregion

        #region Service - Buscar Laudo Por ID DTO
        public async Task<LaudoResponseDto?> BuscarPorIdDto(int id)
        {
            LaudoResponseDto? laudo = await _laudoRepositorio.BuscarPorIdDto(id);

            if (laudo is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Busca do laudo com o ID: {id} foi realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Laudo)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Laudo)} ->
                                        Busca do laudo com o ID: {id} não foi realizada.");

            return laudo ?? throw new Exception("Não foi possível buscar o laudo, a buscar retornou nulo");
        }
        #endregion
        
        #region Service - Buscar Laudo Por ID
        public async Task<LaudoModel?> BuscarPorId(int id)
        {
            LaudoModel? laudo = await _laudoRepositorio.BuscarPorId(id);

            if (laudo is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Busca do laudo com o ID: {id} foi realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Laudo)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Laudo)} ->
                                        Busca do laudo com o ID: {id} não foi realizada.");

            return laudo ?? throw new Exception("Não foi possível buscar o laudo, a buscar retornou nulo");
        }
        #endregion

        #region Service - Buscar Todos os Laudos
        public async Task<List<LaudoResponseDto>> BuscarTodosLaudos()
        {
            List<LaudoResponseDto> laudos = await _laudoRepositorio.BuscarTodosLaudos();

            if (laudos is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Laudo)}: Busca de todos os laudos foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_GET_Laudo)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Laudo)}");

            return laudos ?? throw new Exception("Não foi possível buscar todos os laudos, a busca retornou nulo");
        }
        #endregion
    }
}
