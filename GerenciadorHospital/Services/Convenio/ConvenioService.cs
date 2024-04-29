using GerenciadorHospital.Controllers;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GerenciadorHospital.Services.Convenio
{
    public class ConvenioService : IConvenioService
    {
        private readonly IConvenioRepositorio _convenioRepositorio;
        private readonly ILogger<ConvenioController> _logger;
        MensagensLog mensagensLog = new MensagensLog();

        #region Construtor
        public ConvenioService(IConvenioRepositorio convenioRepositorio,
                               ILogger<ConvenioController> logger)
        {
            _convenioRepositorio = convenioRepositorio;
            _logger = logger;
            _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Os valores foram atribuídos no construtor da Service");
        }
        #endregion

        #region Service - Buscar Todos Convenios
        public async Task<List<ConvenioModel>> BuscarTodosConvenios()
        {
            List<ConvenioModel> convenios = await _convenioRepositorio.BuscarTodosConvenios();
            
            if (convenios is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Busca de todos os convênios realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_GET_Convenio)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Convenio)}");
            
            return convenios ?? throw new Exception("Não foi possível buscar todos os convênios, a busca retornou nulo");
        }
        #endregion

        #region Service - Buscar Convênio por ID
        public async Task<ConvenioModel> BuscarPorId(int id)
        {
            ConvenioModel convenio = await _convenioRepositorio.BuscarPorId(id);

            if (convenio is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Busca de convênio com o ID: {id} realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Convenio)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Convenio)} ->
                                        Busca de convênio com o ID: {id} realizada, porém sem conteúdo.");

            return convenio ?? throw new Exception("Não foi possível buscar convênio por ID, a busca retornou nulo");
        }
        #endregion

        #region Service - Adicionar Convênio
        public async Task<ConvenioModel> Adicionar(ConvenioDto convenioDto)
        {
            ConvenioModel convenioModel = new ConvenioModel(convenioDto);
            ValidaConvenio validaConvenio = new ValidaConvenio(convenioModel);
            validaConvenio.ValidacaoConvenio();

            ConvenioModel convenio = await _convenioRepositorio.Adicionar(convenioModel);

            if (convenio is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Cadastro do convênio realizado.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_POST_Convenio)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_POST_Convenio)}");

            return convenio ?? throw new Exception("Não foi possível cadastrar convênio, a response foi nula");
        }
        #endregion

        #region Service - Atualizar Convênio
        public async Task<ConvenioModel> Atualizar(ConvenioDto convenioDto, int id)
        {
            ConvenioModel convenioModel = new ConvenioModel(convenioDto);
            ValidaConvenio validaConvenio = new ValidaConvenio(convenioModel);
            validaConvenio.ValidacaoConvenio();

            ConvenioModel convenio = await _convenioRepositorio.Atualizar(convenioModel, id);

            if (convenio is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Atualização do convênio realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_PUT_Convenio)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_PUT_Convenio)} ->
                                        Atualização do convênio não foi concluída.");

            return convenio ?? throw new Exception("Não foi possível atualizar o convênio, a response foi nula");
        }
        #endregion

        #region Service - Apagar Convênio
        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _convenioRepositorio.Apagar(id);

            if (apagado)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Remoção do convênio realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_DEL_Convenio)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_DEL_Convenio)}");

            return apagado;
        }
        #endregion
    }
}
