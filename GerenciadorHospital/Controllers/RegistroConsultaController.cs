using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Services.Consulta;
using GerenciadorHospital.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroConsultaController : ControllerBase
    {
        private readonly IRegistroConsultaRepositorio _consultaRepositorio;
        private readonly IPacienteRepositorio _pacienteRepositorio;
        #region Construtor
        public RegistroConsultaController(IRegistroConsultaRepositorio consultaRepositorio, 
                                          IPacienteRepositorio pacienteRepositorio)
        {
            _consultaRepositorio = consultaRepositorio;
            _pacienteRepositorio = pacienteRepositorio;
        }
        #endregion

        #region GET Todas Consultas
        /// <summary>
        /// Busca Todas Consultas
        /// </summary>
        /// <returns>Todas Consultas</returns>
        /// <response code="200">Consultas Retornadas com SUCESSO</response>
        [HttpGet]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<List<RegistroConsultaModel>>> BuscarTodosRegistrosConsultas()
        {
            try
            {
                List<RegistroConsultaModel> consultas = await _consultaRepositorio.BuscarTodosRegistrosConsultas();
                return Ok(consultas);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível buscar todas as consultas. Erro: {erro.Message}");
            }
        }
        #endregion

        #region GET Consulta Por ID
        /// <summary>
        /// Busca Consulta por ID
        /// </summary>
        /// <param name="id">ID da Consulta</param>
        /// <returns>Consulta</returns>
        /// <response code="200">Consulta Retornada com SUCESSO</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<List<RegistroConsultaModel>>> BuscarPorId(int id)
        {
            try
            {
                RegistroConsultaModel consultas = await _consultaRepositorio.BuscarPorId(id);
                return Ok(consultas);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível buscar a consulta com o ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region GET Consulta Por ID do Paciente
        /// <summary>
        /// Busca Consulta por ID
        /// </summary>
        /// <param name="id">ID da Consulta</param>
        /// <param name="statusConsulta">Estado da Consulta</param>
        /// <returns>Consulta</returns>
        /// <response code="200">Consulta Retornada com SUCESSO</response>
        [HttpGet("BuscarConsultaPorPaciente/{id}")]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<RegistroConsultaModel>>> BuscarConsultaPorPacienteId(int id, StatusConsulta statusConsulta)
        {
            try
            {
                List<RegistroConsultaModel> consultas = await _consultaRepositorio.BuscarConsultaPorPacienteId(id, statusConsulta);
                return Ok(consultas);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível buscar a consulta com o ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region GET Consulta Por ID do Médico
        /// <summary>
        /// Busca Consulta por ID
        /// </summary>
        /// <param name="id">ID da Consulta</param>
        /// <param name="statusConsulta">Estado da Consulta</param>
        /// <param name="data">Data da Consulta</param>
        /// <returns>Consulta</returns>
        /// <response code="200">Consulta Retornada com SUCESSO</response>
        [HttpGet("BuscarConsultaPorMedico/{id}")]
        [Authorize(Policy = "StandardRights")]
        public async Task<ActionResult<List<RegistroConsultaModel>>> BuscarConsultaPorMedicoId(int id, StatusConsulta statusConsulta, string? dataInicial, string? dataFinal)
        {
            try
            {
                if (dataInicial == null) dataInicial = string.Empty;
                if (dataFinal == null) dataFinal = string.Empty;
                List<RegistroConsultaModel> consultas = await _consultaRepositorio.BuscarConsultaPorMedicoId(id, statusConsulta, dataInicial, dataFinal);
                return Ok(consultas);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível buscar a consulta com o ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region POST Cadastrar Consulta
        /// <summary>
        /// Cadastrar Consulta
        /// </summary>
        /// <param name="consultaModel">Dados da Consulta</param>
        /// <returns>Consulta Cadastrada</returns>
        /// <response code="200">Consulta Cadastrada com SUCESSO</response>
        [HttpPost]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<RegistroConsultaModel>> Adicionar([FromBody] RegistroConsultaModel consultaModel)
        {
            try
            {
                RegistroConsultaService registroConsultaService = new RegistroConsultaService(_consultaRepositorio, _pacienteRepositorio);
                var response = await registroConsultaService.AdicionarConsulta(consultaModel);

                return Ok(response);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível cadastrar a consulta. Erro: {erro.Message}");
            }
        }
        #endregion

        #region PUT Atualizar Consulta
        /// <summary>
        /// Atualizar Consulta
        /// </summary>
        /// <param name="id">ID da Consulta</param>
        /// <param name="consultaModel">Dados da Consulta</param>
        /// <returns>Consulta Atualizada</returns>
        /// <response code="200">Consulta Atualizada com SUCESSO</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminAndDoctorRights")]
        public async Task<ActionResult<RegistroConsultaModel>> Atualizar([FromBody] RegistroConsultaModel consultaModel, int id)
        {
            try
            {
                consultaModel.Id = id;

                if (consultaModel.EstadoConsulta == Enums.StatusConsulta.Atendida)
                {
                    consultaModel.DataRetorno = DateTime.Now.AddDays(30);
                }

                RegistroConsultaModel consulta = await _consultaRepositorio.Atualizar(consultaModel, id);
                return Ok(consulta);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível atualizar a consulta com o ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion

        #region DELETE Apagar Consulta
        /// <summary>
        /// Apagar Consulta
        /// </summary>
        /// <param name="id">ID da Consulta</param>
        /// <returns>Booleano</returns>
        /// <response code="200">Consulta Apagada com SUCESSO</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<ActionResult<RegistroConsultaModel>> Apagar(int id)
        {
            try
            {
                bool apagado = await _consultaRepositorio.Apagar(id);
                return Ok(apagado);
            }
            catch (Exception erro)
            {
                return BadRequest($"Não foi possível apagar a consulta com o ID: {id}. Erro: {erro.Message}");
            }
        }
        #endregion
    }
}
