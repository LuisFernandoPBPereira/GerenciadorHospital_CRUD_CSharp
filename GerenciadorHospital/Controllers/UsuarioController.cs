using GerenciadorHospital.Dto;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        /// <summary>
        /// Busca Todos os Pacientes
        /// </summary>
        /// <returns>Todos Pacientes</returns>
        /// <response code="200">Pacientes retornados com SUCESSO</response>
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        /// <summary>
        /// Busca Paciente por ID
        /// </summary>
        /// <param name="id">ID do paciente</param>
        /// <returns>Paciente</returns>
        /// <response code="200">Paciente retornado com SUCESSO</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        /// <summary>
        /// Cadastrar um Paciente
        /// </summary>
        /// <param name="requestDto">Dados do Paciente</param>
        /// <returns>Paciente Cadastrado</returns>
        /// <response code="200">Paciente cadastrado com SUCESSO</response>
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Adicionar(UsuarioModel usuarioModel)
        {
            UsuarioModel paciente = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(paciente);
        }

        /// <summary>
        /// Atualizar um Paciente
        /// </summary>
        /// <param name="pacienteModel">Dados do Paciente</param>
        /// <param name="id">ID do Paciente</param>
        /// <returns>O paciente atualizado</returns>
        /// <response code="200">Paciente atualizado com SUCESSO</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        /// <summary>
        /// Apagar um Paciente
        /// </summary>
        /// <param name="id">ID do Paciente</param>
        /// <returns>Um booleano</returns>
        /// <response code="200">Paciente apagado com SUCESSO</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
