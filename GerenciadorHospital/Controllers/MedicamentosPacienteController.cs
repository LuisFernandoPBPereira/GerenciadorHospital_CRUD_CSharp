using GerenciadorHospital.Dto.Requests;
using GerenciadorHospital.Models;
using GerenciadorHospital.Services.Medicamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Tags("Medicamento")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentosPacienteController : ControllerBase
    {
        private readonly IMedicamentosService _medicamentosService;
        private readonly ILogger<MedicamentosPacienteController> _logger;
        #region Construtor
        public MedicamentosPacienteController(IMedicamentosService medicamentosService,
                                              ILogger<MedicamentosPacienteController> logger)
        {
            _medicamentosService = medicamentosService;
            _logger = logger;
            _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medicamento)}: Os valores foram atribuídos no construtor na Controller");
        }
        #endregion

        #region GET Buscar Todos Medicamentos
        /// <summary>
        /// Busca Todos Medicamentos
        /// </summary>
        /// <returns>Todos Medicamentos</returns>
        /// <response code="200">Medicamentos Retornados com SUCESSO</response>
        [HttpGet]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<MedicamentoPacienteModel>>> BuscarTodosMedicamentosPaciente()
        {
            try
            {
                var response = await _medicamentosService.BuscarTodosMedicamentosPaciente();

                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Medicamento)}: Não foi possível buscar todos medicamentos. Erro:{erro.Message}");
                return BadRequest($"Não foi possível buscar todos medicamentos. Erro:{erro.Message}");
            }
        }
        #endregion

        #region GET Buscar Medicamento Por ID
        /// <summary>
        /// Busca Medicamento por ID
        /// </summary>
        /// <param name="id">ID do Medicamento</param>
        /// <returns>Medicamento</returns>
        /// <response code="200">Medicamento Retornado com SUCESSO</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<MedicamentoPacienteModel>>> BuscarPorId(int id)
        {
            try
            {
                var response = await _medicamentosService.BuscarPorId(id);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Medicamento)}: Não foi possível buscar o medicamento com ID: {id}. Erro:{erro.Message}");
                return BadRequest($"Não foi possível buscar o medicamento com ID: {id}. Erro:{erro.Message}");
            }
        }
        #endregion

        #region POST Cadastrar Medicamento
        /// <summary>
        /// Cadastrar Medicamento
        /// </summary>
        /// <param name="medicamentoDto">Dados do Medicamento</param>
        /// <returns>Medicamento Cadastrado</returns>
        /// <response code="200">Medicamento Cadastrado com SUCESSO</response>
        [HttpPost]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<MedicamentoPacienteModel>> Adicionar([FromBody] MedicamentoDto medicamentoDto)
        {
            try
            {
                var response = await _medicamentosService.Adicionar(medicamentoDto);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_POST_Medicamento)}: Não foi possível cadastrar o medicamento. Erro:{erro.Message}");
                return BadRequest($"Não foi possível cadastrar o medicamento. Erro:{erro.Message}");
            }
        }
        #endregion

        #region PUT Atualizar Medicamento
        /// <summary>
        /// Atualizar Medicamento
        /// </summary>
        /// <param name="id">ID do Medicamento</param>
        /// <param name="medicamentoDto">Dados do Medicamento</param>
        /// <returns>Medicamento Atualizado</returns>
        /// <response code="200">Medicamento Atualizado com SUCESSO</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<MedicamentoPacienteModel>> Atualizar([FromBody] MedicamentoDto medicamentoDto, int id)
        {
            try
            {
                var response = await _medicamentosService.Atualizar(medicamentoDto, id);
                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_PUT_Medicamento)}: Não foi possível atualizar o medicamento com ID: {id}. Erro:{erro.Message}");
                return BadRequest($"Não foi possível atualizar o medicamento com ID: {id}. Erro:{erro.Message}");
            }
        }
        #endregion

        #region DELETE Apagar Medicamento
        /// <summary>
        /// Apagar Medicamento
        /// </summary>
        /// <param name="id">ID do Medicamento</param>
        /// <returns>Booleano</returns>
        /// <response code="200">Medicamento Apagado com SUCESSO</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<MedicamentoPacienteModel>> Apagar(int id)
        {
            try
            {
                var response = await _medicamentosService.Apagar(id);

                return Ok(response);
            }
            catch (Exception erro)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_DEL_Medicamento)}: Não foi possível apagar o medicamento com ID: {id}. Erro: {erro.Message}");
                return BadRequest($"Não foi possível apagar o medicamento com ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion
    }
}
