using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<List<TipoExameModel>>> BuscarTodosExames()
        {
            try
            {
                List<TipoExameModel> exames = await _tipoExameRepositorio.BuscarTodosExames();
                return Ok(exames);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível buscar todos exames. Erro: {erro.Message}");
            }
        }

        /// <summary>
        /// Busca Exame por ID
        /// </summary>
        /// <param name="id">ID do Exame</param>
        /// <returns>Exame</returns>
        /// <response code="200">Exame Retornado com SUCESSO</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<TipoExameModel>>> BuscarPorId(int id)
        {
            try
            {
                TipoExameModel exames = await _tipoExameRepositorio.BuscarPorId(id);
                return Ok(exames);
            }
            catch(Exception erro)
            {
                return BadRequest($"Não foi possível buscar o exame com ID: {id}. Erro: {erro.Message}");
            }
        }

        /// <summary>
        /// Cadastrar Exame
        /// </summary>
        /// <param name="tipoExameModel">Dados do Exame</param>
        /// <returns>Exame Cadastrado</returns>
        /// <response code="200">Exame Cadastrado com SUCESSO</response>
        [HttpPost]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<TipoExameModel>> Adicionar([FromBody] TipoExameModel tipoExameModel)
        {
            try
            {
                TipoExameModel exame = await _tipoExameRepositorio.Adicionar(tipoExameModel);
                return Ok(exame);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível cadastrar o exame. Erro: {erro.Message}");
            }
        }

        /// <summary>
        /// Atualizar Exame
        /// </summary>
        /// <param name="id">ID do Exame</param>
        /// <param name="tipoExameModel">Dados do Exame</param>
        /// <returns>Exame Atualizado</returns>
        /// <response code="200">Exame Atualizado com SUCESSO</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<TipoExameModel>> Atualizar([FromBody] TipoExameModel tipoExameModel, int id)
        {
            try
            {
                tipoExameModel.Id = id;
                TipoExameModel exame = await _tipoExameRepositorio.Atualizar(tipoExameModel, id);
                return Ok(exame);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível atualizar o exame com ID: {id}. Erro: {erro.Message}");
            }
        }

        /// <summary>
        /// Apagar Exame
        /// </summary>
        /// <param name="id">ID do Exame</param>
        /// <returns>Booleano</returns>
        /// <response code="200">Exame Apagado com SUCESSO</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<TipoExameModel>> Apagar(int id)
        {
            try
            {
                bool apagado = await _tipoExameRepositorio.Apagar(id);
                return Ok(apagado);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível apagar o exame com ID: {id}. Erro: {erro.Message}");
            }
        }
    }
}
