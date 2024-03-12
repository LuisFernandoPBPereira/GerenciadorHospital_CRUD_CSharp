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

        [HttpGet]
        public async Task<ActionResult<List<MedicamentoPacienteModel>>> BuscarTodosMedicamentosPaciente()
        {
            List<MedicamentoPacienteModel> medicos = await _medicamentosPacienteRepositorio.BuscarTodosMedicamentosPaciente();
            return Ok(medicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<MedicamentoPacienteModel>>> BuscarPorId(int id)
        {
            MedicamentoPacienteModel medicamentos = await _medicamentosPacienteRepositorio.BuscarPorId(id);
            return Ok(medicamentos);
        }

        //Método POST com requisição pelo body para a criação do medicamento de forma assíncrona
        [HttpPost]
        public async Task<ActionResult<MedicamentoPacienteModel>> Adicionar([FromBody] MedicamentoPacienteModel medicoModel)
        {
            MedicamentoPacienteModel medicamentos = await _medicamentosPacienteRepositorio.Adicionar(medicoModel);
            return Ok(medicamentos);
        }

        //Método PUT com requisição pelo body para a atualização do medicamento de forma assíncrona
        [HttpPut("{id}")]
        public async Task<ActionResult<MedicamentoPacienteModel>> Atualizar([FromBody] MedicamentoPacienteModel medicamentoModel, int id)
        {
            medicamentoModel.Id = id;
            MedicamentoPacienteModel medicamentos = await _medicamentosPacienteRepositorio.Atualizar(medicamentoModel, id);
            return Ok(medicamentos);
        }

        //Método DELETE que busca o medicamento pelo ID para medicamento o usuário
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicamentoPacienteModel>> Apagar(int id)
        {
            bool apagado = await _medicamentosPacienteRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
