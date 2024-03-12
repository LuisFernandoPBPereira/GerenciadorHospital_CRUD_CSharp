using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepositorio _medicoRepositorio;
        public MedicoController(IMedicoRepositorio medicoRepositorio)
        {
            _medicoRepositorio = medicoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicoModel>>> BuscarTodosMedicos()
        {
            List<MedicoModel> medicos = await _medicoRepositorio.BuscarTodosMedicos();
            return Ok(medicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<MedicoModel>>> BuscarPorId(int id)
        {
            MedicoModel medicos = await _medicoRepositorio.BuscarPorId(id);
            return Ok(medicos);
        }

        //Método POST com requisição pelo body para a criação do usuário de forma assíncrona
        [HttpPost]
        public async Task<ActionResult<MedicoModel>> Adicionar([FromBody] MedicoModel medicoModel)
        {
            MedicoModel medico = await _medicoRepositorio.Adicionar(medicoModel);
            return Ok(medico);
        }

        //Método PUT com requisição pelo body para a atualização do usuário de forma assíncrona
        [HttpPut("{id}")]
        public async Task<ActionResult<MedicoModel>> Atualizar([FromBody] MedicoModel medicoModel, int id)
        {
            medicoModel.Id = id;
            MedicoModel medico = await _medicoRepositorio.Atualizar(medicoModel, id);
            return Ok(medico);
        }

        //Método DELETE que busca o usuário pelo ID para deletar o usuário
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicoModel>> Apagar(int id)
        {
            bool apagado = await _medicoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
