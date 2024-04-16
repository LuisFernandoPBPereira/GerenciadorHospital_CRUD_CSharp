﻿using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Services.Exame;
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
        #region Construtor
        public TipoExameController(ITipoExameRepositorio tipoExameRepositorio)
        {
            _tipoExameRepositorio = tipoExameRepositorio;
        }
        #endregion

        #region GET Buscar Todos Exames
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
                TipoExameService tipoExameService = new TipoExameService(_tipoExameRepositorio);
                var response = await tipoExameService.BuscarTodosExames();

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível buscar todos exames. Erro: {erro.Message}");
            }
        }
        #endregion

        #region GET Buscar Exame Por ID
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
                TipoExameService tipoExameService = new TipoExameService(_tipoExameRepositorio);
                var response = await tipoExameService.BuscarPorId(id);

                return Ok(response);
            }
            catch(Exception erro)
            {
                return BadRequest($"Não foi possível buscar o exame com ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region POST Cadastrar Exame
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
                TipoExameService tipoExameService = new TipoExameService(_tipoExameRepositorio);
                var response = await tipoExameService.Adicionar(tipoExameModel);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível cadastrar o exame. Erro: {erro.Message}");
            }
        }
        #endregion

        #region PUT Atualizar Exame
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
                TipoExameService tipoExameService = new TipoExameService(_tipoExameRepositorio);
                var response = await tipoExameService.Atualizar(tipoExameModel, id);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível atualizar o exame com ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region DELETE Apagar Exame
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
                TipoExameService tipoExameService = new TipoExameService(_tipoExameRepositorio);
                var response = await tipoExameService.Apagar(id);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível apagar o exame com ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion
    }
}
