using GerenciadorHospital.Dto;
using GerenciadorHospital.Models;
using GerenciadorHospital.Services.Medico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Tags("Médico")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        private readonly ILogger<MedicoController> _logger;
        #region Construtor
        public MedicoController(ILogger<MedicoController> logger,
                                IMedicoService medicoService)
        {
            _medicoService = medicoService;
            _logger = logger;
        }
        #endregion

        #region GET Buscar Todos Médicos
        /// <summary>
        /// Busca Todos Médicos
        /// </summary>
        /// <returns>Todos Médicos</returns>
        /// <response code="200">Médicos Retornados com SUCESSO</response>
        [HttpGet]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<List<MedicoModel>>> BuscarTodosMedicos()
        {
            try
            {
                var response = await _medicoService.BuscarTodosMedicos();

                return Ok(response);
            }
            catch(Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Medico)}: Não foi possível buscar todos os médicos. Erro: {erro.Message}");
                return BadRequest($"Não foi possível buscar todos os médicos. Erro: {erro.Message}");
            }
        }
        #endregion

        #region GET Buscar Médico Por ID
        /// <summary>
        /// Busca Médico por ID
        /// </summary>
        /// <param name="id">ID do Médico</param>
        /// <returns>Médicos</returns>
        /// <response code="200">Médico Retornado com SUCESSO</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<List<MedicoModel>>> BuscarPorId(int id)
        {
            try
            {
                var response = await _medicoService.BuscarPorId(id);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Medico)}: Não foi possível buscar o médico com ID: {id}. Erro: {erro.Message}");
                return BadRequest($"Não foi possível buscar o médico com ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region GET Buscar Documento do Médico Por ID
        /// <summary>
        /// Busca Médico por ID
        /// </summary>
        /// <param name="id">ID do Médico</param>
        /// <returns>Médicos</returns>
        /// <response code="200">Médico Retornado com SUCESSO</response>
        [HttpGet("BuscarDocMedico/{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<List<MedicoModel>>> BuscarDocMedicoPorId(int id)
        {
            try
            {
                var response = await _medicoService.BuscarDocMedicoPorId(id);

                return response;
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Medico)}: Não foi possível buscar documento do médico com ID: {id}. Erro: {erro.Message}");
                return BadRequest($"Não foi possível buscar documento do médico com ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region POST Cadastrar Médico
        /// <summary>
        /// Cadastrar Médico
        /// </summary>
        /// <param name="medicoDto">Dados do Médico</param>
        /// <returns>Médico Cadastrado</returns>
        /// <response code="200">Médico Cadastrado com SUCESSO</response>
        [HttpPost]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<MedicoModel>> Adicionar(MedicoDto medicoDto)
        {
            try
            {
                var response = await _medicoService.Adicionar(medicoDto);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_POST_Medico)}: Não foi possível cadastrar o médico. Erro:{erro.Message}");
                return BadRequest($"Não foi possível cadastrar o médico. Erro:{erro.Message}");
            }
        }
        #endregion

        #region PUT Atualizar Médico
        /// <summary>
        /// Atualizar Médico
        /// </summary>
        /// <param name="id">ID do Médico</param>
        /// <param name="medicoDto">Dados do Médico</param>
        /// <returns>Médico Atualizado</returns>
        /// <response code="200">Médico Atualizado com SUCESSO</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<MedicoModel>> Atualizar(MedicoDto medicoDto, int id)
        {
            try
            {
                var response = await _medicoService.Atualizar(medicoDto, id);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_PUT_Medico)}: Não foi possível atualizar o médico com ID: {id}. Erro: {erro.Message}");
                return BadRequest($"Não foi possível atualizar o médico com ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region DELETE Apagar Médico
        /// <summary>
        /// Apagar Médico
        /// </summary>
        /// <param name="id">ID do Médico</param>
        /// <returns>Booleano</returns>
        /// <response code="200">Médico Apagado com SUCESSO</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<MedicoModel>> Apagar(int id)
        {
            try
            {
                var response = await _medicoService.Apagar(id);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_DEL_Medico)}: Não possível apagar o médico com o ID: {id}. Erro: {erro.Message}");
                return BadRequest($"Não possível apagar o médico com o ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion
    }
}
