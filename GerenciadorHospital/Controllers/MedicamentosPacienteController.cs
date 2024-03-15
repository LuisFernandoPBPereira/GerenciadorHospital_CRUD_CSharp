using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentosPacienteController : ControllerBase
    {
        private readonly IMedicamentosPacienteRepositorio _medicamentosPacienteRepositorio;
        public MedicamentosPacienteController(IMedicamentosPacienteRepositorio medicamentoRepositorio)
        {
            _medicamentosPacienteRepositorio = medicamentoRepositorio;
        }

        /// <summary>
        /// Busca Todos Medicamentos
        /// </summary>
        /// <returns>Todos Medicamentos</returns>
        /// <response code="200">Medicamentos Retornados com SUCESSO</response>
        [HttpGet]
        public async Task<ActionResult<List<MedicamentoPacienteModel>>> BuscarTodosMedicamentosPaciente()
        {
            List<MedicamentoPacienteModel> medicos = await _medicamentosPacienteRepositorio.BuscarTodosMedicamentosPaciente();
            return Ok(medicos);
        }

        /// <summary>
        /// Busca Medicamento por ID
        /// </summary>
        /// <param name="id">ID do Medicamento</param>
        /// <returns>Medicamento</returns>
        /// <response code="200">Medicamento Retornado com SUCESSO</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<MedicamentoPacienteModel>>> BuscarPorId(int id)
        {
            MedicamentoPacienteModel medicamentos = await _medicamentosPacienteRepositorio.BuscarPorId(id);
            return Ok(medicamentos);
        }

        /// <summary>
        /// Cadastrar Medicamento
        /// </summary>
        /// <param name="medicamentoModel">Dados do Medicamento</param>
        /// <returns>Medicamento Cadastrado</returns>
        /// <response code="200">Medicamento Cadastrado com SUCESSO</response>
        [HttpPost]
        public async Task<ActionResult<MedicamentoPacienteModel>> Adicionar([FromBody] MedicamentoPacienteModel medicamentoModel)
        {
            MedicamentoPacienteModel medicamentos = await _medicamentosPacienteRepositorio.Adicionar(medicamentoModel);
            return Ok(medicamentos);
        }

        /// <summary>
        /// Atualizar Medicamento
        /// </summary>
        /// <param name="id">ID do Medicamento</param>
        /// <param name="medicamentoModel">Dados do Medicamento</param>
        /// <returns>Medicamento Atualizado</returns>
        /// <response code="200">Medicamento Atualizado com SUCESSO</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<MedicamentoPacienteModel>> Atualizar([FromBody] MedicamentoPacienteModel medicamentoModel, int id)
        {
            medicamentoModel.Id = id;
            MedicamentoPacienteModel medicamentos = await _medicamentosPacienteRepositorio.Atualizar(medicamentoModel, id);
            return Ok(medicamentos);
        }

        /// <summary>
        /// Apagar Medicamento
        /// </summary>
        /// <param name="id">ID do Medicamento</param>
        /// <returns>Booleano</returns>
        /// <response code="200">Medicamento Apagado com SUCESSO</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicamentoPacienteModel>> Apagar(int id)
        {
            bool apagado = await _medicamentosPacienteRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
