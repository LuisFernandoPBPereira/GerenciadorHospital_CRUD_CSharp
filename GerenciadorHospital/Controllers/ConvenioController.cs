using GerenciadorHospital.Dto;
using GerenciadorHospital.Models;
using GerenciadorHospital.Services.Convenio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Tags("Convênio")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConvenioController : ControllerBase
    {
        private readonly IConvenioService _convenioService;
        private readonly ILogger<ConvenioController> _logger;
        #region Construtor
        public ConvenioController(ILogger<ConvenioController> logger,
                                  IConvenioService convenioService)
        {
            _convenioService = convenioService;
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
                var response  = await _convenioService.BuscarTodosConvenios();
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
                var response = await _convenioService.BuscarPorId(id);
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
        /// <param name="convenioDto">Dados do convênio</param>
        /// <response code="200">Convênio Cadastrado com SUCESSO</response>
        [HttpPost]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<ConvenioModel>> Adicionar([FromBody] ConvenioDto convenioDto)
        {
            try
            {
                var response = await _convenioService.Adicionar(convenioDto);
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
        /// <param name="convenioDto">Dados do Convênio</param>
        /// <param name="id">ID do Convênio</param>
        /// <returns>Os dados atualizados</returns>
        /// <response code="200">Convênio Atualizado com SUCESSO</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<ConvenioModel>> Atualizar([FromBody] ConvenioDto convenioDto, int id)
        {
            try
            {
                var response = await _convenioService.Atualizar(convenioDto, id);
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
                var response = await _convenioService.Apagar(id);
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
