using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Services.Convenio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvenioController : ControllerBase
    {
        private readonly IConvenioRepositorio _convenioRepositorio;
        private readonly ILogger<ConvenioController> _logger;
        #region Construtor
        public ConvenioController(IConvenioRepositorio convenioRepositorio, 
                                  ILogger<ConvenioController> logger)
        {
            _convenioRepositorio = convenioRepositorio;
            _logger = logger;
            _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Convenio)}: Os valores foram atribuídos no construtor da Controller");
        }
        #endregion

        #region GET Todos Convênios
        /// <summary>
        /// Busca Todos Convênios
        /// </summary>
        /// <returns>Todos Convênios</returns>
        /// <response code="200">Convênios Retornados com SUCESSO</response>
        [HttpGet]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<ConvenioModel>>> BuscarTodosConvenios()
        {
            try
            {
                ConvenioService convenioService = new ConvenioService(_convenioRepositorio, _logger);
                var response  = await convenioService.BuscarTodosConvenios();

                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Convenio)}: Não foi possível buscar todos os convênios. Erro:{erro.Message}");
                return BadRequest($"Não foi possível buscar todos os convênios. Erro:{erro.Message}");
            }
        }
        #endregion

        #region GET Buscar Convênio Por ID
        /// <summary>
        /// Busca Convênio por ID
        /// </summary>
        /// <param name="id">ID do convênio</param>
        /// <returns>Convênio</returns>
        /// <response code="200">Convênio Retornado com SUCESSO</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<ConvenioModel>>> BuscarPorId(int id)
        {
            try
            {
                ConvenioService convenioService = new ConvenioService(_convenioRepositorio, _logger);
                var response = await convenioService.BuscarPorId(id);

                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Convenio)}: Não foi possível buscar o convênio com o ID: {id}. Erro:{erro.Message}");
                return BadRequest($"Não foi possível buscar o convênio com o ID: {id}. Erro:{erro.Message}");
            }
        }
        #endregion

        #region POST Cadastrar Convênio
        /// <summary>
        /// Cadastrar Convênio
        /// </summary>
        /// <param name="convenioModel">Dados do convênio</param>
        /// <response code="200">Convênio Cadastrado com SUCESSO</response>
        [HttpPost]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<ConvenioModel>> Adicionar([FromBody] ConvenioModel convenioModel)
        {
            try
            {
                ConvenioService convenioService = new ConvenioService(_convenioRepositorio, _logger);
                var response = await convenioService.Adicionar(convenioModel);

                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{Enums.CodigosLogErro.E_POST_Convenio}: Não foi possível cadastrar o convênio. Erro:{erro.Message}");
                return BadRequest($"Não foi possível cadastrar o convênio. Erro:{erro.Message}");
            }
        }
        #endregion

        #region PUT Atualizar Convênio
        /// <summary>
        /// Atualizar Convênio
        /// </summary>
        /// <param name="convenioModel">Dados do Convênio</param>
        /// <param name="id">ID do Convênio</param>
        /// <returns>Os dados atualizados</returns>
        /// <response code="200">Convênio Atualizado com SUCESSO</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<ConvenioModel>> Atualizar([FromBody] ConvenioModel convenioModel, int id)
        {
            try
            {
                ConvenioService convenioService = new ConvenioService(_convenioRepositorio, _logger);
                var response = await convenioService.Atualizar(convenioModel, id);

                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{Enums.CodigosLogErro.E_PUT_Convenio}: Não foi possível atualizar o convênio com ID: {id}. Erro:{erro.Message}");
                return BadRequest($"Não foi possível atualizar o convênio com ID: {id}. Erro:{erro.Message}");
            }
        }
        #endregion

        #region DELETE Apagar Convênio
        /// <summary>
        /// Apagar Convênio
        /// </summary>
        /// <param name="id">ID do Convênio</param>
        /// <returns>Booleano</returns>
        /// <response code="200">Convênio Apagado com SUCESSO</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<ConvenioModel>> Apagar(int id)
        {
            try
            {
                ConvenioService convenioService = new ConvenioService(_convenioRepositorio, _logger);
                var response = await convenioService.Apagar(id);

                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_DEL_Convenio)}: Não foi possível apagar o convênio com ID: {id}. Erro:{erro.Message}");
                return BadRequest($"Não foi possível apagar o convênio com ID: {id}. Erro:{erro.Message}");
            }
        }
        #endregion
    }
}
