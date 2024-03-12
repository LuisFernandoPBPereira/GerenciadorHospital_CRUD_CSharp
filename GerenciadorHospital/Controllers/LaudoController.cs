using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaudoController : ControllerBase
    {
        private readonly ILaudoRepositorio _laudoRepositorio;
        public LaudoController(ILaudoRepositorio laudoRepositorio)
        {
            _laudoRepositorio = laudoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<LaudoModel>>> BuscarTodosLaudos()
        {
            List<LaudoModel> laudos = await _laudoRepositorio.BuscarTodosLaudos();
            return Ok(laudos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<LaudoModel>>> BuscarPorId(int id)
        {
            LaudoModel laudos = await _laudoRepositorio.BuscarPorId(id);
            return Ok(laudos);
        }

        //Método POST com requisição pelo body para a criação do laudo de forma assíncrona
        [HttpPost]
        public async Task<ActionResult<LaudoModel>> Adicionar([FromBody] LaudoModel laudoModel)
        {
            LaudoModel laudo = await _laudoRepositorio.Adicionar(laudoModel);
            return Ok(laudo);
        }

        //Método PUT com requisição pelo body para a atualização do laudo de forma assíncrona
        [HttpPut("{id}")]
        public async Task<ActionResult<LaudoModel>> Atualizar([FromBody] LaudoModel laudoModel, int id)
        {
            laudoModel.Id = id;
            LaudoModel laudo = await _laudoRepositorio.Atualizar(laudoModel, id);
            return Ok(laudo);
        }

        //Método DELETE que busca o laudo pelo ID para deletar o laudo
        [HttpDelete("{id}")]
        public async Task<ActionResult<LaudoModel>> Apagar(int id)
        {
            bool apagado = await _laudoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
