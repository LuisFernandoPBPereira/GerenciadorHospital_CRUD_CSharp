using GerenciadorHospital.Controllers;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Convenio
{
    public class ConvenioService : IConvenioService
    {
        private readonly IConvenioRepositorio _convenioRepositorio;
        private readonly ILogger<ConvenioController> _logger;
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
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Convenio)}: Busca de todos os convênios realizada, porém sem conteúdo.");
            
            return convenios;
        }

        public async Task<ConvenioModel> BuscarPorId(int id)
        {
            ConvenioModel convenio = await _convenioRepositorio.BuscarPorId(id);

            if (convenio is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Busca de convênio com o ID: {id} realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Convenio)}: Busca de convênio com o ID: {id} realizada, porém sem conteúdo.");

            return convenio;
        }

        public async Task<ConvenioModel> Adicionar(ConvenioModel convenioModel)
        {
            ConvenioModel convenio = await _convenioRepositorio.Adicionar(convenioModel);

            if (convenio is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Cadastro do convênio realizado.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Convenio)}: Cadastro do convênio não foi concluído.");


            return convenio;
        }

        public async Task<ConvenioModel> Atualizar(ConvenioModel convenioModel, int id)
        {
            convenioModel.Id = id;
            ConvenioModel convenio = await _convenioRepositorio.Atualizar(convenioModel, id);

            if (convenio is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Atualização do convênio realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Convenio)}: Atualização do convênio não foi concluída.");

            return convenio;
        }

        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _convenioRepositorio.Apagar(id);

            if (apagado)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Remoção do convênio realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Convenio)}: Remoção do convênio não foi concluída.");

            return apagado;
        }
    }
}
