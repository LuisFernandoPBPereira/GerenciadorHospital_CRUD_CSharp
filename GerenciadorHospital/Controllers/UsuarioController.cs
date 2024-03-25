using Azure.Core;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Services;
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


        public UsuarioController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

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
            var response = await _authenticationService.Register(usuarioModel);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto usuarioModel)
        {
            var response = await _authenticationService.Login(usuarioModel);

            return Ok(response);
        }
    }
}
