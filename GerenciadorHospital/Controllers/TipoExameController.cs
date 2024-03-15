using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoExameController : ControllerBase
    {
        private readonly ITipoExameRepositorio _tipoExameRepositorio;
        public TipoExameController(ITipoExameRepositorio tipoExameRepositorio)
        {
            _tipoExameRepositorio = tipoExameRepositorio;
        }

        /// <summary>
        /// Busca Todos Exames
        /// </summary>
        /// <returns>Todos Exames</returns>
        /// <response code="200">Exames Retornados com SUCESSO</response>
        [HttpGet]
        public async Task<ActionResult<List<TipoExameModel>>> BuscarTodosExames()
        {
            List<TipoExameModel> exames = await _tipoExameRepositorio.BuscarTodosExames();
            return Ok(exames);
        }

        /// <summary>
        /// Busca Exame por ID
        /// </summary>
        /// <param name="id">ID do Exame</param>
        /// <returns>Exame</returns>
        /// <response code="200">Exame Retornado com SUCESSO</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<TipoExameModel>>> BuscarPorId(int id)
        {
            TipoExameModel exames = await _tipoExameRepositorio.BuscarPorId(id);
            return Ok(exames);
        }

        /// <summary>
        /// Cadastrar Exame
        /// </summary>
        /// <param name="tipoExameModel">Dados do Exame</param>
        /// <returns>Exame Cadastrado</returns>
        /// <response code="200">Exame Cadastrado com SUCESSO</response>
        [HttpPost]
        public async Task<ActionResult<TipoExameModel>> Adicionar([FromBody] TipoExameModel tipoExameModel)
        {
            TipoExameModel exame = await _tipoExameRepositorio.Adicionar(tipoExameModel);
            return Ok(exame);
        }

        /// <summary>
        /// Atualizar Exame
        /// </summary>
        /// <param name="id">ID do Exame</param>
        /// <param name="tipoExameModel">Dados do Exame</param>
        /// <returns>Exame Atualizado</returns>
        /// <response code="200">Exame Atualizado com SUCESSO</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<TipoExameModel>> Atualizar([FromBody] TipoExameModel tipoExameModel, int id)
        {
            tipoExameModel.Id = id;
            TipoExameModel exame = await _tipoExameRepositorio.Atualizar(tipoExameModel, id);
            return Ok(exame);
        }

        /// <summary>
        /// Apagar Exame
        /// </summary>
        /// <param name="id">ID do Exame</param>
        /// <returns>Booleano</returns>
        /// <response code="200">Exame Apagado com SUCESSO</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoExameModel>> Apagar(int id)
        {
            bool apagado = await _tipoExameRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
