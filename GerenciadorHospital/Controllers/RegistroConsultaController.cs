using GerenciadorHospital.Dto.Requests;
using GerenciadorHospital.Dto.Responses;
using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using GerenciadorHospital.Services.Consulta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Tags("Consulta")]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroConsultaController : ControllerBase
    {
        private readonly IRegistroConsultaService _registroConsultaService;
        private readonly ILogger<RegistroConsultaController> _logger;
        #region Construtor
        public RegistroConsultaController(ILogger<RegistroConsultaController> logger,
                                          IRegistroConsultaService registroConsultaService)
        {
            _logger = logger;
            _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Consulta)}: Os valores foram atribuídos no construtor da Controller.");
            _registroConsultaService = registroConsultaService;
        }
        #endregion

        #region GET Todas Consultas
        /// <summary>
        /// Busca Todas Consultas
        /// </summary>
        /// <returns>Todas Consultas</returns>
        /// <response code="200">Consultas Retornadas com SUCESSO</response>
        [HttpGet]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<List<ConsultaResponseDto>>> BuscarTodosRegistrosConsultas()
        {
            try
            {                
                var response = await _registroConsultaService.BuscarTodosRegistrosConsultas();
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Consulta)}: Não foi possível buscar todas as consultas. Erro: {erro.Message}");
                return BadRequest($"Não foi possível buscar todas as consultas. Erro: {erro.Message}");
            }
        }
        #endregion
        
        #region GET Consulta Por ID
        /// <summary>
        /// Busca Consulta por ID
        /// </summary>
        /// <param name="id">ID da Consulta</param>
        /// <returns>Consulta</returns>
        /// <response code="200">Consulta Retornada com SUCESSO</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<List<ConsultaResponseDto>>> BuscarPorId(int id)
        {
            try
            {
                var response = await _registroConsultaService.BuscarPorIdDto(id);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Consulta)}: Não foi possível buscar a consulta com o ID: {id}. Erro: {erro.Message}");
                return BadRequest($"Não foi possível buscar a consulta com o ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region GET Consulta Por ID do Paciente
        /// <summary>
        /// Busca Consulta por ID
        /// </summary>
        /// <param name="id">ID da Consulta</param>
        /// <param name="statusConsulta">Estado da Consulta</param>
        /// <returns>Consulta</returns>
        /// <response code="200">Consulta Retornada com SUCESSO</response>
        [HttpGet("BuscarConsultaPorPaciente/{id}")]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<ConsultaResponseDto>>> BuscarConsultaPorPacienteId(int id, StatusConsulta statusConsulta)
        {
            try
            {
                var response = await _registroConsultaService.BuscarConsultaPorPacienteId(id, statusConsulta);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Consulta)}: Não foi possível buscar a consulta com o ID: {id}. Erro: {erro.Message}");
                return BadRequest($"Não foi possível buscar a consulta com o ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region GET Consulta Por ID do Médico
        /// <summary>
        /// Busca Consulta por ID
        /// </summary>
        /// <param name="id">ID da Consulta</param>
        /// <param name="statusConsulta">Estado da Consulta</param>
        /// <param name="dataInicial">Data inicial de busca da Consulta</param>
        /// <param name="dataFinal">Data final de busca da Consulta</param>
        /// <returns>Consulta</returns>
        /// <response code="200">Consulta Retornada com SUCESSO</response>
        [HttpGet("BuscarConsultaPorMedico/{id}")]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<ConsultaResponseDto>>> BuscarConsultaPorMedicoId(int id, StatusConsulta statusConsulta, string? dataInicial, string? dataFinal)
        {
            try
            {
                var response = await _registroConsultaService.BuscarConsultaPorMedicoId(id, statusConsulta, dataInicial, dataFinal);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Consulta)}: Não foi possível buscar a consulta com o ID: {id}. Erro: {erro.Message}");
                return BadRequest($"Não foi possível buscar a consulta com o ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region POST Cadastrar Consulta
        /// <summary>
        /// Cadastrar Consulta
        /// </summary>
        /// <param name="consultaDto">Dados da Consulta</param>
        /// <returns>Consulta Cadastrada</returns>
        /// <response code="200">Consulta Cadastrada com SUCESSO</response>
        [HttpPost]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<RegistroConsultaModel>> Adicionar([FromBody] RegistroConsultaDto consultaDto)
        {
            try
            {
                var response = await _registroConsultaService.Adicionar(consultaDto);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_POST_Consulta)}: Não foi possível cadastrar a consulta. Erro: {erro.Message}");
                return BadRequest($"Não foi possível cadastrar a consulta. Erro: {erro.Message}");
            }
        }
        #endregion

        #region PUT Atualizar Consulta
        /// <summary>
        /// Atualizar Consulta
        /// </summary>
        /// <param name="id">ID da Consulta</param>
        /// <param name="consultaDto">Dados da Consulta</param>
        /// <returns>Consulta Atualizada</returns>
        /// <response code="200">Consulta Atualizada com SUCESSO</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<RegistroConsultaModel>> Atualizar([FromBody] RegistroConsultaDto consultaDto, int id)
        {
            try
            {
                var response = await _registroConsultaService.Atualizar(consultaDto, id);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_PUT_Consulta)}: Não foi possível atualizar a consulta com o ID: {id}. Erro: {erro.Message}");
                return BadRequest($"Não foi possível atualizar a consulta com o ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region DELETE Apagar Consulta
        /// <summary>
        /// Apagar Consulta
        /// </summary>
        /// <param name="id">ID da Consulta</param>
        /// <returns>Booleano</returns>
        /// <response code="200">Consulta Apagada com SUCESSO</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<RegistroConsultaModel>> Apagar(int id)
        {
            try
            {
                var response = await _registroConsultaService.Apagar(id);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_DEL_Consulta)}: Não foi possível apagar a consulta com o ID: {id}. Erro: {erro.Message}");
                return BadRequest($"Não foi possível apagar a consulta com o ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion
    }
}
