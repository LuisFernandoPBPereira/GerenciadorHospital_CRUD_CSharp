using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Services.Laudo;
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
        #region Construtor
        public LaudoController(ILaudoRepositorio laudoRepositorio)
        {
            _laudoRepositorio = laudoRepositorio;
        }
        #endregion

        #region GET Todos Laudos
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
                LaudoService laudoService = new LaudoService(_laudoRepositorio);
                var response = await laudoService.BuscarTodosLaudos();
                
                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível buscar todos os laudos. Erro:{erro.Message}");
            }
        }
        #endregion

        #region GET Buscar Laudo Por ID
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
                LaudoService laudoService = new LaudoService(_laudoRepositorio);
                var response = await laudoService.BuscarPorId(id);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível buscar o laudo com ID: {id}. Erro:{erro.Message}");
            }
        }
        #endregion

        #region GET Buscar Laudo com Filtro
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
                LaudoService laudoService = new LaudoService(_laudoRepositorio);
                var response = await laudoService.BuscarLaudo(dataInicial, dataFinal, medicoId, pacienteId);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível buscar o laudo com ID: . Erro: {erro.Message}");
            }
        }
        #endregion

        #region POST Cadastrar Laudo
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
                LaudoService laudoService = new LaudoService(_laudoRepositorio);
                var response = await laudoService.Adicionar(laudoModel);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível cadastrar o laudo. Erro:{erro.Message}");
            }
        }
        #endregion

        #region PUT Atualizar Laudo
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
                LaudoService laudoService = new LaudoService(_laudoRepositorio);
                var response = await laudoService.Atualizar(laudoModel, id);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível atualizar o laudo com ID: {id}. Erro:{erro.Message}");
            }
        }
        #endregion

        #region DELETE Apagar Laudo
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
                LaudoService laudoService = new LaudoService(_laudoRepositorio);
                var response = await laudoService.Apagar(id);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível apagar o laudo com ID: {id}. Erro:{erro.Message}");
            }
        }
        #endregion
    }
}
