using GerenciadorHospital.Dto.Requests;
using GerenciadorHospital.Dto.Responses;
using GerenciadorHospital.Models;
using GerenciadorHospital.Services.Laudo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Tags("Laudo")]
    [Route("api/[controller]")]
    [ApiController]
    public class LaudoController : ControllerBase
    {
        private readonly ILaudoService _laudoService;
        private readonly ILogger<LaudoController> _logger;
        #region Construtor
        public LaudoController(ILogger<LaudoController> logger,
                               ILaudoService laudoService)
        {
            _laudoService = laudoService;
            _logger = logger;
        }
        #endregion

        #region GET Todos Laudos
        /// <summary>
        /// Busca Todos Laudos
        /// </summary>
        /// <returns>Todos Laudos</returns>
        /// <response code="200">Laudos Retornados com SUCESSO</response>
        [HttpGet]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<LaudoResponseDto>>> BuscarTodosLaudos()
        {
            try
            {
                var response = await _laudoService.BuscarTodosLaudos();   
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Laudo)}: Não foi possível buscar todos os laudos. Erro:{erro.Message}");
                return BadRequest($"Não foi possível buscar todos os laudos. Erro:{erro.Message}");
            }
        }
        #endregion

        #region GET Buscar Laudo Por ID
        /// <summary>
        /// Busca Laudos por ID
        /// </summary>
        /// <param name="id">ID do Laudo</param>
        /// <returns>Laudo</returns>
        /// <response code="200">Laudo Retornado com SUCESSO</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<LaudoResponseDto>> BuscarPorId(int id)
        {
            try
            {
                var response = await _laudoService.BuscarPorIdDto(id);

                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Laudo)}: Não foi possível buscar o laudo com ID: {id}. Erro:{erro.Message}");
                return BadRequest($"Não foi possível buscar o laudo com ID: {id}. Erro:{erro.Message}");
            }
        }
        #endregion

        #region GET Buscar Imagem do Laudo Por ID
        /// <summary>
        /// Busca Laudos por ID
        /// </summary>
        /// <param name="id">ID do Laudo</param>
        /// <returns>Laudo</returns>
        /// <response code="200">Laudo Retornado com SUCESSO</response>
        [HttpGet("BuscarImagemLaudo/{id}")]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<LaudoModel>> BuscarImagemLaudoPorId(int id)
        {
            try
            {
                var response = await _laudoService.BuscarImagemLaudoPorId(id);
                return response;
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Laudo)}: Não foi possível buscar o laudo com ID: {id}. Erro:{erro.Message}");
                return BadRequest($"Não foi possível buscar o laudo com ID: {id}. Erro:{erro.Message}");
            }
        }
        #endregion

        #region GET Buscar Laudo com Filtro
        /// <summary>
        /// Busca Laudos por ID
        /// </summary>
        /// <param name="dataInicial">Data inicial do Laudo</param>
        /// <param name="dataFinal">Data final do Laudo</param>
        /// <param name="medicoId">ID medico</param>
        /// <param name="pacienteId">ID paciente</param>
        /// <returns>Laudo</returns>
        /// <response code="200">Laudo Retornado com SUCESSO</response>
        [HttpGet("BuscarLaudo")]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<LaudoResponseDto>>> BuscarLaudo(string? dataInicial, string? dataFinal, int medicoId, int pacienteId)
        {
            try
            {
                var response = await _laudoService.BuscarLaudo(dataInicial, dataFinal, medicoId, pacienteId);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Laudo)}: Não foi possível buscar o laudo com ID: . Erro: {erro.Message}");
                return BadRequest($"Não foi possível buscar o laudo com ID: . Erro: {erro.Message}");
            }
        }
        #endregion

        #region POST Cadastrar Laudo
        /// <summary>
        /// Cadastrar Laudo
        /// </summary>
        /// <param name="laudoDto">Dados do Laudo</param>
        /// <returns>Laudo Cadastrado</returns>
        /// <response code="200">Laudo Cadastrado com SUCESSO</response>
        [HttpPost]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<LaudoModel>> Adicionar(LaudoDto laudoDto)
        {
            try
            {
                var response = await _laudoService.Adicionar(laudoDto);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_POST_Laudo)}: Não foi possível cadastrar o laudo. Erro:{erro.Message}");
                return BadRequest($"Não foi possível cadastrar o laudo. Erro:{erro.Message}");
            }
        }
        #endregion

        #region PUT Atualizar Laudo
        /// <summary>
        /// Atualizar Laudo
        /// </summary>
        /// <param name="id">ID do Laudo</param>
        /// <param name="laudoDto">Dados do Laudo</param>
        /// <returns>Laudo atualizado</returns>
        /// <response code="200">Laudo Atualizado com SUCESSO</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<LaudoModel>> Atualizar(LaudoDto laudoDto, int id)
        {
            try
            {
                var response = await _laudoService.Atualizar(laudoDto, id);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_PUT_Laudo)}: Não foi possível atualizar o laudo com ID: {id}. Erro:{erro.Message}");
                return BadRequest($"Não foi possível atualizar o laudo com ID: {id}. Erro:{erro.Message}");
            }
        }
        #endregion

        #region DELETE Apagar Laudo
        /// <summary>
        /// Apagar Laudo
        /// </summary>
        /// <param name="id">ID do Laudo</param>
        /// <returns>Booleano</returns>
        /// <response code="200">Laudo Apagado com SUCESSO</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<LaudoModel>> Apagar(int id)
        {
            try
            {
                var response = await _laudoService.Apagar(id);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_DEL_Laudo)}: Não foi possível apagar o laudo com ID: {id}. Erro:{erro.Message}");
                return BadRequest($"Não foi possível apagar o laudo com ID: {id}. Erro:{erro.Message}");
            }
        }
        #endregion
    }
}
