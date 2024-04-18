using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Services.Medicamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentosPacienteController : ControllerBase
    {
        private readonly IMedicamentosPacienteRepositorio _medicamentosPacienteRepositorio;
        private readonly ILogger<MedicamentosPacienteController> _logger;
        #region Construtor
        public MedicamentosPacienteController(IMedicamentosPacienteRepositorio medicamentoRepositorio,
                                              ILogger<MedicamentosPacienteController> logger)
        {
            _medicamentosPacienteRepositorio = medicamentoRepositorio;
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
                MedicamentosService medicamentosService = new MedicamentosService(_medicamentosPacienteRepositorio, _logger);
                var response = await medicamentosService.BuscarTodosMedicamentosPaciente();

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
                MedicamentosService medicamentosService = new MedicamentosService(_medicamentosPacienteRepositorio, _logger);
                var response = await medicamentosService.BuscarPorId(id);

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
        /// <param name="medicamentoModel">Dados do Medicamento</param>
        /// <returns>Medicamento Cadastrado</returns>
        /// <response code="200">Medicamento Cadastrado com SUCESSO</response>
        [HttpPost]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<MedicamentoPacienteModel>> Adicionar([FromBody] MedicamentoPacienteModel medicamentoModel)
        {
            try
            {
                MedicamentosService medicamentosService = new MedicamentosService(_medicamentosPacienteRepositorio, _logger);
                var response = await medicamentosService.Adicionar(medicamentoModel);

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
        /// <param name="medicamentoModel">Dados do Medicamento</param>
        /// <returns>Medicamento Atualizado</returns>
        /// <response code="200">Medicamento Atualizado com SUCESSO</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<MedicamentoPacienteModel>> Atualizar([FromBody] MedicamentoPacienteModel medicamentoModel, int id)
        {
            try
            {
                MedicamentosService medicamentosService = new MedicamentosService(_medicamentosPacienteRepositorio, _logger);
                var response = await medicamentosService.Atualizar(medicamentoModel, id);

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
                MedicamentosService medicamentosService = new MedicamentosService(_medicamentosPacienteRepositorio, _logger);
                var response = await medicamentosService.Apagar(id);

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
