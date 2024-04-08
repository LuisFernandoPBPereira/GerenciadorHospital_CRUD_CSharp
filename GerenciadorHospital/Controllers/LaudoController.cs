using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Busca Todos Laudos
        /// </summary>
        /// <returns>Todos Laudos</returns>
        /// <response code="200">Laudos Retornados com SUCESSO</response>
        [HttpGet]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<LaudoModel>>> BuscarTodosLaudos()
        {
            try
            {
                List<LaudoModel> laudos = await _laudoRepositorio.BuscarTodosLaudos();
                return Ok(laudos);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível buscar todos os laudos. Erro:{erro.Message}");
            }
        }

        /// <summary>
        /// Busca Laudos por ID
        /// </summary>
        /// <param name="id">ID do Laudo</param>
        /// <returns>Laudo</returns>
        /// <response code="200">Laudo Retornado com SUCESSO</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<LaudoModel>>> BuscarPorId(int id)
        {
            try
            {
                LaudoModel laudos = await _laudoRepositorio.BuscarPorId(id);
                return Ok(laudos);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível buscar o laudo com ID: {id}. Erro:{erro.Message}");
            }
        }

        /// <summary>
        /// Busca Laudos por ID
        /// </summary>
        /// <param name="dataInicial">Data inicial do Laudo</param>
        /// <param name="dataFinal">Data final do Laudo</param>
        /// <param name="medicoId">ID medico</param>
        /// <param name="pacienteId">ID paciente</param>
        /// <returns>Laudo</returns>
        /// <response code="200">Laudo Retornado com SUCESSO</response>
        [HttpGet("BuscarLaudo")]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<LaudoModel>>> BuscarLaudo(string? dataInicial, string? dataFinal, int medicoId, int pacienteId)
        {
            try
            {
                dataInicial = dataInicial ?? string.Empty;
                dataFinal = dataFinal ?? string.Empty;
                List<LaudoModel> laudos = await _laudoRepositorio.BuscarLaudo(dataInicial, dataFinal, medicoId, pacienteId);
                return Ok(laudos);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível buscar o laudo com ID: . Erro: {erro.Message}");
            }
        }

        /// <summary>
        /// Cadastrar Laudo
        /// </summary>
        /// <param name="laudoModel">Dados do Laudo</param>
        /// <returns>Laudo Cadastrado</returns>
        /// <response code="200">Laudo Cadastrado com SUCESSO</response>
        [HttpPost]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<LaudoModel>> Adicionar([FromBody] LaudoModel laudoModel)
        {
            try
            {
                LaudoModel laudo = await _laudoRepositorio.Adicionar(laudoModel);
                return Ok(laudo);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível cadastrar o laudo. Erro:{erro.Message}");
            }
        }

        /// <summary>
        /// Atualizar Laudo
        /// </summary>
        /// <param name="id">ID do Laudo</param>
        /// <param name="laudoModel">Dados do Laudo</param>
        /// <returns>Laudo atualizado</returns>
        /// <response code="200">Laudo Atualizado com SUCESSO</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<LaudoModel>> Atualizar([FromBody] LaudoModel laudoModel, int id)
        {
            try
            {
                laudoModel.Id = id;
                LaudoModel laudo = await _laudoRepositorio.Atualizar(laudoModel, id);
                return Ok(laudo);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível atualizar o laudo com ID: {id}. Erro:{erro.Message}");
            }
        }

        /// <summary>
        /// Apagar Laudo
        /// </summary>
        /// <param name="id">ID do Laudo</param>
        /// <returns>Booleano</returns>
        /// <response code="200">Laudo Apagado com SUCESSO</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<LaudoModel>> Apagar(int id)
        {
            try
            {
                bool apagado = await _laudoRepositorio.Apagar(id);
                return Ok(apagado);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível apagar o laudo com ID: {id}. Erro:{erro.Message}");
            }
        }
    }
}
