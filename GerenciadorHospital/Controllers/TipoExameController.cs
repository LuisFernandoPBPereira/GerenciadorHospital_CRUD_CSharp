using GerenciadorHospital.Dto.Requests;
using GerenciadorHospital.Models;
using GerenciadorHospital.Services.Exame;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Tags("Exame")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoExameController : ControllerBase
    {
        private readonly ITipoExameService _tipoExameService;
        private readonly ILogger<TipoExameController> _logger;
        #region Construtor
        public TipoExameController(ILogger<TipoExameController> logger,
                                   ITipoExameService tipoExameService)
        {
            _tipoExameService = tipoExameService;
            _logger = logger;
        }
        #endregion

        #region GET Buscar Todos Exames
        /// <summary>
        /// Busca Todos Exames
        /// </summary>
        /// <returns>Todos Exames</returns>
        /// <response code="200">Exames Retornados com SUCESSO</response>
        [HttpGet]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<List<TipoExameModel>>> BuscarTodosExames()
        {
            try
            {
                var response = await _tipoExameService.BuscarTodosExames();
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Exame)}: Não foi possível buscar todos exames. Erro: {erro.Message}");
                return BadRequest($"Não foi possível buscar todos exames. Erro: {erro.Message}");
            }
        }
        #endregion

        #region GET Buscar Exame Por ID
        /// <summary>
        /// Busca Exame por ID
        /// </summary>
        /// <param name="id">ID do Exame</param>
        /// <returns>Exame</returns>
        /// <response code="200">Exame Retornado com SUCESSO</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<TipoExameModel>>> BuscarPorId(int id)
        {
            try
            {
                var response = await _tipoExameService.BuscarPorId(id);
                return Ok(response);
            }
            catch(Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Exame)}Não foi possível buscar o exame com ID: {id}. Erro: {erro.Message}");
                return BadRequest($"Não foi possível buscar o exame com ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region POST Cadastrar Exame
        /// <summary>
        /// Cadastrar Exame
        /// </summary>
        /// <param name="exameDto">Dados do Exame</param>
        /// <returns>Exame Cadastrado</returns>
        /// <response code="200">Exame Cadastrado com SUCESSO</response>
        [HttpPost]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<TipoExameModel>> Adicionar([FromBody] TipoExameDto exameDto)
        {
            try
            {
                var response = await _tipoExameService.Adicionar(exameDto);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_POST_Exame)}Não foi possível cadastrar o exame. Erro: {erro.Message}");
                return BadRequest($"Não foi possível cadastrar o exame. Erro: {erro.Message}");
            }
        }
        #endregion

        #region PUT Atualizar Exame
        /// <summary>
        /// Atualizar Exame
        /// </summary>
        /// <param name="id">ID do Exame</param>
        /// <param name="exameDto">Dados do Exame</param>
        /// <returns>Exame Atualizado</returns>
        /// <response code="200">Exame Atualizado com SUCESSO</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<TipoExameModel>> Atualizar([FromBody] TipoExameDto exameDto, int id)
        {
            try
            {
                var response = await _tipoExameService.Atualizar(exameDto, id);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_PUT_Exame)}: Não foi possível atualizar o exame com ID: {id}. Erro: {erro.Message}");
                return BadRequest($"Não foi possível atualizar o exame com ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region DELETE Apagar Exame
        /// <summary>
        /// Apagar Exame
        /// </summary>
        /// <param name="id">ID do Exame</param>
        /// <returns>Booleano</returns>
        /// <response code="200">Exame Apagado com SUCESSO</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<TipoExameModel>> Apagar(int id)
        {
            try
            {
                var response = await _tipoExameService.Apagar(id);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_DEL_Exame)}: Não foi possível apagar o exame com ID: {id}. Erro: {erro.Message}");
                return BadRequest($"Não foi possível apagar o exame com ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion
    }
}
