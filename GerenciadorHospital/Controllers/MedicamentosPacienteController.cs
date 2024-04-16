using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
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
        #region Construtor
        public MedicamentosPacienteController(IMedicamentosPacienteRepositorio medicamentoRepositorio)
        {
            _medicamentosPacienteRepositorio = medicamentoRepositorio;
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
                List<MedicamentoPacienteModel> medicos = await _medicamentosPacienteRepositorio.BuscarTodosMedicamentosPaciente();
                return Ok(medicos);
            }
            catch (Exception erro)
            {
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
                MedicamentoPacienteModel medicamentos = await _medicamentosPacienteRepositorio.BuscarPorId(id);
                return Ok(medicamentos);
            }
            catch (Exception erro)
            {
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
                MedicamentoPacienteModel medicamentos = await _medicamentosPacienteRepositorio.Adicionar(medicamentoModel);
                return Ok(medicamentos);
            }
            catch (Exception erro)
            {
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
                medicamentoModel.Id = id;
                MedicamentoPacienteModel medicamentos = await _medicamentosPacienteRepositorio.Atualizar(medicamentoModel, id);
                return Ok(medicamentos);
            }
            catch (Exception erro)
            {
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
                bool apagado = await _medicamentosPacienteRepositorio.Apagar(id);
                return Ok(apagado);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível apagar o medicamento com ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion
    }
}
