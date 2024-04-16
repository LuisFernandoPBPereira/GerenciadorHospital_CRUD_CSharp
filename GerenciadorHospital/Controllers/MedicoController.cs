using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Services;
using GerenciadorHospital.Services.Medico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepositorio _medicoRepositorio;
        private readonly IAuthenticationService _authenticationService;
        #region Construtor
        public MedicoController(IMedicoRepositorio medicoRepositorio,
                                IAuthenticationService authenticationService)
        {
            _medicoRepositorio = medicoRepositorio;
            _authenticationService = authenticationService;
        }
        #endregion

        #region GET Buscar Todos Médicos
        /// <summary>
        /// Busca Todos Médicos
        /// </summary>
        /// <returns>Todos Médicos</returns>
        /// <response code="200">Médicos Retornados com SUCESSO</response>
        [HttpGet]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<List<MedicoModel>>> BuscarTodosMedicos()
        {
            try
            {
                MedicoService medicoService = new MedicoService(_authenticationService, _medicoRepositorio);
                var response = await medicoService.BuscarTodosMedicos();

                return Ok(response);
            }
            catch(Exception erro)
            {
                return BadRequest($"Não foi possível buscar todos os médicos. Erro: {erro.Message}");
            }
        }
        #endregion

        #region GET Buscar Médico Por ID
        /// <summary>
        /// Busca Médico por ID
        /// </summary>
        /// <param name="id">ID do Médico</param>
        /// <returns>Médicos</returns>
        /// <response code="200">Médico Retornado com SUCESSO</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<List<MedicoModel>>> BuscarPorId(int id)
        {
            try
            {
                MedicoService medicoService = new MedicoService(_authenticationService, _medicoRepositorio);
                var response = await medicoService.BuscarPorId(id);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível buscar o médico com ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region POST Cadastrar Médico
        /// <summary>
        /// Cadastrar Médico
        /// </summary>
        /// <param name="medicoModel">Dados do Médico</param>
        /// <returns>Médico Cadastrado</returns>
        /// <response code="200">Médico Cadastrado com SUCESSO</response>
        [HttpPost]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<MedicoModel>> Adicionar([FromBody] MedicoModel medicoModel)
        {
            try
            {
                MedicoService medicoService = new MedicoService(_authenticationService, _medicoRepositorio);
                var response = await medicoService.Adicionar(medicoModel);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível cadastrar o médico. Erro:{erro.Message}");
            }
        }
        #endregion

        #region PUT Atualizar Médico
        /// <summary>
        /// Atualizar Médico
        /// </summary>
        /// <param name="id">ID do Médico</param>
        /// <param name="medicoModel">Dados do Médico</param>
        /// <returns>Médico Atualizado</returns>
        /// <response code="200">Médico Atualizado com SUCESSO</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<MedicoModel>> Atualizar([FromBody] MedicoModel medicoModel, int id)
        {
            try
            {
                MedicoService medicoService = new MedicoService(_authenticationService, _medicoRepositorio);
                var response = await medicoService.Atualizar(medicoModel, id);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível atualizar o médico com ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region DELETE Apagar Médico
        /// <summary>
        /// Apagar Médico
        /// </summary>
        /// <param name="id">ID do Médico</param>
        /// <returns>Booleano</returns>
        /// <response code="200">Médico Apagado com SUCESSO</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<MedicoModel>> Apagar(int id)
        {
            try
            {
                MedicoService medicoService = new MedicoService(_authenticationService, _medicoRepositorio);
                var response = await medicoService.Apagar(id);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não possível apagar o médico com o ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion
    }
}
