using GerenciadorHospital.Dto;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Services.Exame;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoExameController : ControllerBase
    {
        private readonly ITipoExameRepositorio _tipoExameRepositorio;
        private readonly ILogger<TipoExameController> _logger;
        #region Construtor
        public TipoExameController(ITipoExameRepositorio tipoExameRepositorio, 
                                   ILogger<TipoExameController> logger)
        {
            _tipoExameRepositorio = tipoExameRepositorio;
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
                TipoExameService tipoExameService = new TipoExameService(_tipoExameRepositorio, _logger);
                var response = await tipoExameService.BuscarTodosExames();

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
                TipoExameService tipoExameService = new TipoExameService(_tipoExameRepositorio, _logger);
                var response = await tipoExameService.BuscarPorId(id);

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
                TipoExameService tipoExameService = new TipoExameService(_tipoExameRepositorio, _logger);
                var response = await tipoExameService.Adicionar(exameDto);

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
                TipoExameService tipoExameService = new TipoExameService(_tipoExameRepositorio, _logger);
                var response = await tipoExameService.Atualizar(exameDto, id);

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
                TipoExameService tipoExameService = new TipoExameService(_tipoExameRepositorio, _logger);
                var response = await tipoExameService.Apagar(id);

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
