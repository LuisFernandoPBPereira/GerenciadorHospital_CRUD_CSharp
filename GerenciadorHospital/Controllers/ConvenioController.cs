using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvenioController : ControllerBase
    {
        private readonly IConvenioRepositorio _convenioRepositorio;
        public ConvenioController(IConvenioRepositorio convenioRepositorio)
        {
            _convenioRepositorio = convenioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConvenioModel>>> BuscarTodosConvenios()
        {
            List<ConvenioModel> convenios = await _convenioRepositorio.BuscarTodosConvenios();
            return Ok(convenios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ConvenioModel>>> BuscarPorId(int id)
        {
            ConvenioModel convenio = await _convenioRepositorio.BuscarPorId(id);
            return Ok(convenio);
        }

        //Método POST com requisição pelo body para a criação do usuário de forma assíncrona
        [HttpPost]
        public async Task<ActionResult<ConvenioModel>> Adicionar([FromBody] ConvenioModel convenioModel)
        {
            ConvenioModel convenio = await _convenioRepositorio.Adicionar(convenioModel);
            return Ok(convenio);
        }

        //Método PUT com requisição pelo body para a atualização do usuário de forma assíncrona
        [HttpPut("{id}")]
        public async Task<ActionResult<ConvenioModel>> Atualizar([FromBody] ConvenioModel convenioModel, int id)
        {
            convenioModel.Id = id;
            ConvenioModel convenio = await _convenioRepositorio.Atualizar(convenioModel, id);
            return Ok(convenio);
        }

        //Método DELETE que busca o usuário pelo ID para deletar o usuário
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConvenioModel>> Apagar(int id)
        {
            bool apagado = await _convenioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
