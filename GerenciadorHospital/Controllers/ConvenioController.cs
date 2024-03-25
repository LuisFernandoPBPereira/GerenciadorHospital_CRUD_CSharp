using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Busca Todos Convênios
        /// </summary>
        /// <returns>Todos Convênios</returns>
        /// <response code="200">Convênios Retornados com SUCESSO</response>
        [HttpGet]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<ConvenioModel>>> BuscarTodosConvenios()
        {
            List<ConvenioModel> convenios = await _convenioRepositorio.BuscarTodosConvenios();
            return Ok(convenios);
        }

        /// <summary>
        /// Busca Convênio por ID
        /// </summary>
        /// <param name="id">ID do convênio</param>
        /// <returns>Convênio</returns>
        /// <response code="200">Convênio Retornado com SUCESSO</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<ConvenioModel>>> BuscarPorId(int id)
        {
            ConvenioModel convenio = await _convenioRepositorio.BuscarPorId(id);
            return Ok(convenio);
        }

        /// <summary>
        /// Cadastrar Convênio
        /// </summary>
        /// <param name="convenioModel">Dados do convênio</param>
        /// <response code="200">Convênio Cadastrado com SUCESSO</response>
        [HttpPost]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<ConvenioModel>> Adicionar([FromBody] ConvenioModel convenioModel)
        {
            ConvenioModel convenio = await _convenioRepositorio.Adicionar(convenioModel);
            return Ok(convenio);
        }

        /// <summary>
        /// Atualizar Convênio
        /// </summary>
        /// <param name="convenioModel">Dados do Convênio</param>
        /// <param name="id">ID do Convênio</param>
        /// <returns>Os dados atualizados</returns>
        /// <response code="200">Convênio Atualizado com SUCESSO</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<ConvenioModel>> Atualizar([FromBody] ConvenioModel convenioModel, int id)
        {
            convenioModel.Id = id;
            ConvenioModel convenio = await _convenioRepositorio.Atualizar(convenioModel, id);
            return Ok(convenio);
        }

        /// <summary>
        /// Apagar Convênio
        /// </summary>
        /// <param name="id">ID do Convênio</param>
        /// <returns>Booleano</returns>
        /// <response code="200">Convênio Apagado com SUCESSO</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<ConvenioModel>> Apagar(int id)
        {
            bool apagado = await _convenioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
