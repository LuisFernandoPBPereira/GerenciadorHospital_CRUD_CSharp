using FileTypeChecker;
using FileTypeChecker.Abstracts;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Services;
using GerenciadorHospital.Services.Paciente;
using GerenciadorHospital.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace GerenciadorHospital.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacienteController : ControllerBase
{
    private readonly IPacienteService _pacienteService;
    private readonly ILogger<PacienteController> _logger;

    #region Construtor
    public PacienteController(ILogger<PacienteController> logger,
                              IPacienteService pacienteService)
    {
        _logger = logger;
        _pacienteService = pacienteService;
    }
    #endregion

    #region GET Buscar Todos Pacientes
    /// <summary>
    /// Busca Todos os Pacientes
    /// </summary>
    /// <returns>Todos Pacientes</returns>
    /// <response code="200">Pacientes retornados com SUCESSO</response>
    [HttpGet]
    [Authorize(Policy = "AdminAndDoctorRights")]
    public async Task<ActionResult<List<PacienteModel>>> BuscarTodosPacientes()
    {
        try
        {
            var response = await _pacienteService.BuscarTodosPacientes();
            return Ok(response);
        }
        catch(Exception erro)
        {
            _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Paciente)}: Não foi possível buscar todos os pacientes. Erro: {erro.Message}");
            return BadRequest($"Não foi possível buscar todos os pacientes. Erro: {erro.Message}");
        }
    }
    #endregion

    #region GET Buscar Paciente Por ID
    /// <summary>
    /// Busca Paciente por ID
    /// </summary>
    /// <param name="id">ID do paciente</param>
    /// <returns>Paciente</returns>
    /// <response code="200">Paciente retornado com SUCESSO</response>
    [HttpGet("{id}")]
    [Authorize(Policy = "AdminAndDoctorRights")]
    public async Task<ActionResult<List<PacienteModel>>> BuscarPorId(int id)
    {
        try
        {
            var response = await _pacienteService.BuscarPorId(id);
            return Ok(response);
        }
        catch (Exception erro)
        {
            _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Paciente)}: Não foi possívell buscar o paciente com o ID: {id}. Erro: {erro.Message}");
            return BadRequest($"Não foi possívell buscar o paciente com o ID: {id}. Erro: {erro.Message}");
        }
    }
    #endregion

    #region GET Buscar Documento do Convênio Por ID
    /// <summary>
    /// Busca Imagem do Documento do Convênio do Paciente
    /// </summary>
    /// <param name="id">ID do paciente</param>
    /// <returns>A Imagem do Documento do Convênio</returns>
    /// <response code="200">Imagem retornada com SUCESSO</response>
    [HttpGet("MostrarDocConvenio/{id}")]
    [Authorize(Policy = "AdminAndDoctorRights")]
    public async Task<ActionResult<List<PacienteModel>>> BuscarDocConvenioPorId(int id)
    {
        try
        {
            var response = await _pacienteService.BuscarDocConvenioPorId(id);
            return Ok(response);
        }
        catch (Exception erro)
        {
            _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Paciente)}: Não foi possível buscar o documento do convênio com ID: {id}. Erro: {erro.Message}");
            return BadRequest($"Não foi possível buscar o documento do convênio com ID: {id}. Erro: {erro.Message}");
        }
    }
    #endregion

    #region GET Buscar Documento do Paciente Por ID
    /// <summary>
    /// Buscar Imagem do Documento do Paciente
    /// </summary>
    /// <param name="id">ID do Paciente</param>
    /// <returns>A imagem do documento</returns>
    /// <response code="200">Imagem retornada com sucesso</response>
    [HttpGet("MostrarDoc/{id}")]
    [Authorize(Policy = "AdminAndDoctorRights")]
    public async Task<ActionResult<MedicoModel>> BuscarDocPorId(int id)
    {
        try
        {
            var response = await _pacienteService.BuscarDocPorId(id);
            return response;
        }
        catch (Exception erro)
        {
            _logger.LogError($"{nameof(Enums.CodigosLogErro.E_GET_Paciente)}: Não foi possível buscar o documento do paciente com o ID: {id}. Erro: {erro.Message}");
            return BadRequest($"Não foi possível buscar o documento do paciente com o ID: {id}. Erro: {erro.Message}");
        }
    }
    #endregion

    #region POST Cadastrar Paciente 
    /// <summary>
    /// Cadastrar um Paciente
    /// </summary>
    /// <param name="pacienteDto">Dados do Paciente</param>
    /// <returns>Paciente Cadastrado</returns>
    /// <response code="200">Paciente cadastrado com SUCESSO</response>
    [HttpPost]
    [Authorize(Policy = "AdminAndDoctorRights")]
    public async Task<ActionResult<PacienteModel>> Adicionar(PacienteDto pacienteDto)
    {
        try 
        {
            var response = await _pacienteService.AdicionarPaciente(pacienteDto);
            
            return Ok(response);
        }
        catch (Exception erro)
        {
            _logger.LogError($"{nameof(Enums.CodigosLogErro.E_POST_Paciente)}: Não foi possível cadastrar o paciente. Erro: {erro.Message}");
            return BadRequest($"Não foi possível cadastrar o paciente. Erro: {erro.Message}");
        }
    }
    #endregion

    #region PUT Atualizar Paciente
    /// <summary>
    /// Atualizar um Paciente
    /// </summary>
    /// <param name="pacienteDto">Dados do Paciente</param>
    /// <param name="id">ID do Paciente</param>
    /// <returns>O paciente atualizado</returns>
    /// <response code="200">Paciente atualizado com SUCESSO</response>
    [HttpPut("{id}")]
    [Authorize(Policy = "StandardRights")]
    public async Task<ActionResult<PacienteModel>> Atualizar(PacienteDto pacienteDto, int id)    {
        try
        {
            var response = await _pacienteService.Atualizar(pacienteDto, id);
            return Ok(response);
        }
        catch (Exception erro)
        {
            _logger.LogError($"{nameof(Enums.CodigosLogErro.E_PUT_Paciente)}: Não foi possível atualizar o paciente com ID: {id}. Erro: {erro.Message}");
            return BadRequest($"Não foi possível atualizar o paciente com ID: {id}. Erro: {erro.Message}");
        }
    }
    #endregion

    #region PUT Atualizar Documento do Paciente
    /// <summary>
    /// Atualizar um Paciente
    /// </summary>
    /// <param name="documentoImagemDto">Dados do Paciente</param>
    /// <param name="id">ID do Paciente</param>
    /// <returns>O paciente atualizado</returns>
    /// <response code="200">Paciente atualizado com SUCESSO</response>
    [HttpPut("AtualizarDoc/{id}")]
    [Authorize(Policy = "StandardRights")]
    public async Task<ActionResult<PacienteModel>> AtualizarDoc(DocumentoImagemDto documentoImagemDto, int id)
    {
        try
        {
            var response = await _pacienteService.AtualizarDoc(documentoImagemDto, id);
            return Ok(response);
        }
        catch (Exception erro)
        {
            _logger.LogError($"{nameof(Enums.CodigosLogErro.E_PUT_Paciente)}: Não foi possível atualizar o documento do paciente com o ID: {id}. Erro: {erro.Message}");
            return BadRequest($"Não foi possível atualizar o documento do paciente com o ID: {id}. Erro: {erro.Message}");
        }

    }
    #endregion

    #region DELETE Apagar Paciente
    /// <summary>
    /// Apagar um Paciente
    /// </summary>
    /// <param name="id">ID do Paciente</param>
    /// <returns>Um booleano</returns>
    /// <response code="200">Paciente apagado com SUCESSO</response>
    [HttpDelete("{id}")]
    [Authorize(Policy = "ElevatedRights")]
    public async Task<ActionResult<PacienteModel>> Apagar(int id)
    {
        try
        {
            var response = await _pacienteService.Apagar(id);

            return Ok(response);
        }
        catch (Exception erro)
        {
            _logger.LogError($"{nameof(Enums.CodigosLogErro.E_DEL_Paciente)}: Não foi possível apagar o paciente com o ID: {id}. Erro: {erro.Message}");
            return BadRequest($"Não foi possível apagar o paciente com o ID: {id}. Erro: {erro.Message}");
        }
    }
    #endregion
}
