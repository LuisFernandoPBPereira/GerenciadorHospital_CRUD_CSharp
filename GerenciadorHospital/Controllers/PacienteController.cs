using FileTypeChecker;
using FileTypeChecker.Abstracts;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacienteController : ControllerBase
{
    private readonly IPacienteRepositorio _pacienteRepositorio;

    public PacienteController(IPacienteRepositorio pacienteRepositorio)
    {
        _pacienteRepositorio = pacienteRepositorio;
    }

    /// <summary>
    /// Busca Todos os Pacientes
    /// </summary>
    /// <returns>Todos Pacientes</returns>
    /// <response code="200">Pacientes retornados com SUCESSO</response>
    [HttpGet]
    [Authorize(Policy = "ElevatedRights")]
    public async Task<ActionResult<List<PacienteModel>>> BuscarTodosPacientes()
    {
        List<PacienteModel> pacientes = await _pacienteRepositorio.BuscarTodosPacientes();
        return Ok(pacientes);
    }

    /// <summary>
    /// Busca Paciente por ID
    /// </summary>
    /// <param name="id">ID do paciente</param>
    /// <returns>Paciente</returns>
    /// <response code="200">Paciente retornado com SUCESSO</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<List<PacienteModel>>> BuscarPorId(int id)
    {
        PacienteModel paciente = await _pacienteRepositorio.BuscarPorId(id);
        return Ok(paciente);
    }

    /// <summary>
    /// Busca Imagem do Documento do Convênio do Paciente
    /// </summary>
    /// <param name="id">ID do paciente</param>
    /// <returns>A Imagem do Documento do Convênio</returns>
    /// <response code="200">Imagem retornada com SUCESSO</response>
    [HttpGet("MostrarDocConvenio/{id}")]
    public async Task<ActionResult<List<PacienteModel>>> BuscarDocConvenioPorId(int id)
    {
        //Capturamos o paciente pelo ID
        PacienteModel paciente = await _pacienteRepositorio.BuscarDocConvenioPorId(id);

        if (paciente.TemConvenio == false)
            return BadRequest("Este paciente não possui convênio");

        string caminho = paciente.ImgCarteiraDoConvenio;

        var imagem = new BuscaImagem(paciente);
        
        return imagem.BuscarImagem(caminho);
    }

    /// <summary>
    /// Buscar Imagem do Documento do Paciente
    /// </summary>
    /// <param name="id">ID do Paciente</param>
    /// <returns>A imagem do documento</returns>
    /// <response code="200">Imagem retornada com sucesso</response>
    [HttpGet("MostrarDoc/{id}")]
    public async Task<ActionResult<List<PacienteModel>>> BuscarDocPorId(int id)
    {
        PacienteModel paciente = await _pacienteRepositorio.BuscarDocPorId(id);
        
        string caminho = paciente.ImgDocumento;

        var imagem = new BuscaImagem(paciente);

        return imagem.BuscarImagem(caminho);
    }

    /// <summary>
    /// Cadastrar um Paciente
    /// </summary>
    /// <param name="requestDto">Dados do Paciente</param>
    /// <returns>Paciente Cadastrado</returns>
    /// <response code="200">Paciente cadastrado com SUCESSO</response>
    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<PacienteModel>> Adicionar(PacienteResquestDto requestDto)
    {
        //É instanciado um novo objeto para a validação das imagens carregadas na requisição
        ValidaImagem validaImagem = new ValidaImagem(requestDto);
        var requestDtoValidado = validaImagem.ValidacaoImagem();

        if (requestDtoValidado)
        {
            PacienteModel paciente = await _pacienteRepositorio.Adicionar(requestDto);
            return Ok(paciente);
        }
        else
        {
            return BadRequest("Não foi possível cadastrar o paciente: Imagem inválida ou inexistente");
        }
    }

    /// <summary>
    /// Atualizar um Paciente
    /// </summary>
    /// <param name="pacienteModel">Dados do Paciente</param>
    /// <param name="id">ID do Paciente</param>
    /// <returns>O paciente atualizado</returns>
    /// <response code="200">Paciente atualizado com SUCESSO</response>
    [HttpPut("{id}")]
    public async Task<ActionResult<PacienteModel>> Atualizar([FromBody] PacienteModel pacienteModel, int id)
    {
        pacienteModel.Id = id;
        PacienteModel paciente = await _pacienteRepositorio.Atualizar(pacienteModel, id);
        return Ok(paciente);
    }

    /// <summary>
    /// Apagar um Paciente
    /// </summary>
    /// <param name="id">ID do Paciente</param>
    /// <returns>Um booleano</returns>
    /// <response code="200">Paciente apagado com SUCESSO</response>
    [HttpDelete("{id}")]
    public async Task<ActionResult<PacienteModel>> Apagar(int id)
    {
        bool apagado = await _pacienteRepositorio.Apagar(id);
        return Ok(apagado);
    }
}
