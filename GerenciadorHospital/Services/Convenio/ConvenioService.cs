using GerenciadorHospital.Controllers;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Convenio
{
    public class ConvenioService : IConvenioService
    {
        private readonly IConvenioRepositorio _convenioRepositorio;
        private readonly ILogger<ConvenioController> _logger;
        MensagensLog mensagensLog = new MensagensLog();
        public ConvenioService(IConvenioRepositorio convenioRepositorio,
                               ILogger<ConvenioController> logger)
        {
            _convenioRepositorio = convenioRepositorio;
            _logger = logger;
            _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Os valores foram atribuídos no construtor da Service");
        }

        public async Task<List<ConvenioModel>> BuscarTodosConvenios()
        {
            List<ConvenioModel> convenios = await _convenioRepositorio.BuscarTodosConvenios();
            
            if (convenios is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Busca de todos os convênios realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_GET_Convenio)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Convenio)}");
            
            return convenios;
        }

        public async Task<ConvenioModel> BuscarPorId(int id)
        {
            ConvenioModel convenio = await _convenioRepositorio.BuscarPorId(id);

            if (convenio is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Busca de convênio com o ID: {id} realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Convenio)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Convenio)} ->
                                        Busca de convênio com o ID: {id} realizada, porém sem conteúdo.");

            return convenio;
        }

        public async Task<ConvenioModel> Adicionar(ConvenioDto convenioDto)
        {
            ConvenioModel convenioModel = new ConvenioModel(convenioDto);
            ConvenioModel convenio = await _convenioRepositorio.Adicionar(convenioModel);

            if (convenio is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Cadastro do convênio realizado.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_POST_Convenio)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_POST_Convenio)}");


            return convenio;
        }

        public async Task<ConvenioModel> Atualizar(ConvenioDto convenioDto, int id)
        {
            ConvenioModel convenioModel = new ConvenioModel(convenioDto);
            ConvenioModel convenio = await _convenioRepositorio.Atualizar(convenioModel, id);

            if (convenio is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Atualização do convênio realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_PUT_Convenio)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_PUT_Convenio)} ->
                                        Atualização do convênio não foi concluída.");

            return convenio;
        }

        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _convenioRepositorio.Apagar(id);

            if (apagado)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Remoção do convênio realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_DEL_Convenio)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_DEL_Convenio)}");

            return apagado;
        }
    }
}
