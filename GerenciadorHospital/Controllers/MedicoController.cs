﻿using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Services;
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
        public MedicoController(IMedicoRepositorio medicoRepositorio,
                                IAuthenticationService authenticationService)
        {
            _medicoRepositorio = medicoRepositorio;
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Busca Todos Médicos
        /// </summary>
        /// <returns>Todos Médicos</returns>
        /// <response code="200">Médicos Retornados com SUCESSO</response>
        [HttpGet]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<List<MedicoModel>>> BuscarTodosMedicos()
        {
            List<MedicoModel> medicos = await _medicoRepositorio.BuscarTodosMedicos();
            return Ok(medicos);
        }

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
            MedicoModel medicos = await _medicoRepositorio.BuscarPorId(id);
            return Ok(medicos);
        }

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
            MedicoModel medico = await _medicoRepositorio.Adicionar(medicoModel);

            CadastroRequestDto novoMedico = new CadastroRequestDto();

            novoMedico.Nome = medico.Nome;
            novoMedico.UserName = medico.Crm;
            novoMedico.Cpf = medico.Cpf;
            novoMedico.Senha = medico.Senha;
            novoMedico.DataNasc = medico.DataNasc;
            novoMedico.Endereco = medico.Endereco;
            novoMedico.Role = Role.Medico;

            await _authenticationService.Register(novoMedico);

            return Ok(medico);
        }

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
            medicoModel.Id = id;
            MedicoModel medico = await _medicoRepositorio.Atualizar(medicoModel, id);
            return Ok(medico);
        }

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
            bool apagado = await _medicoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
