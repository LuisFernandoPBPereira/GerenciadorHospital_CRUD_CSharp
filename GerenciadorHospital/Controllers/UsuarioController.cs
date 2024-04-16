using Azure.Core;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Extensions;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Services;
using GerenciadorHospital.Services.Usuario;
using GerenciadorHospital.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        #region Construtor
        public UsuarioController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        #endregion

        #region POST Cadastrar Usuário
        /// <summary>
        /// Cadastrar um Paciente
        /// </summary>
        /// <param name="usuarioModel">Dados do Paciente</param>
        /// <returns>Paciente Cadastrado</returns>
        /// <response code="200">Paciente cadastrado com SUCESSO</response>
        [AllowAnonymous]
        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastrar([FromBody] CadastroRequestDto usuarioModel)
        {
            try
            {
                UsuarioService usuarioService = new UsuarioService(_authenticationService);
                var response = await usuarioService.Cadastrar(usuarioModel);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível cadastrar o usuário. Erro: {erro.Message}");
            }
        }
        #endregion

        #region POST Efetuar Login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto usuarioModel)
        {
            try
            {
                UsuarioService usuarioService = new UsuarioService(_authenticationService);
                var response = await usuarioService.Login(usuarioModel);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível realizar o login. Erro:{erro.Message}");
            }
        }
        #endregion
    }
}
