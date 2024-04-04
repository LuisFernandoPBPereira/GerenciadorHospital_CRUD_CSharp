using FileTypeChecker;
using FileTypeChecker.Abstracts;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Services;
using GerenciadorHospital.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace GerenciadorHospital.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacienteController : ControllerBase
{
    private readonly IPacienteRepositorio _pacienteRepositorio;
    private readonly IAuthenticationService _authenticationService;

    public PacienteController(IPacienteRepositorio pacienteRepositorio,
                              IAuthenticationService authenticationService)
    {
        _pacienteRepositorio = pacienteRepositorio;
        _authenticationService = authenticationService;
    }

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
            List<PacienteModel> pacientes = await _pacienteRepositorio.BuscarTodosPacientes();
            return Ok(pacientes);
        }
        catch(Exception erro)
        {
            return BadRequest($"Não foi possível buscar todos os pacientes. Erro: {erro.Message}");
        }
    }

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
            PacienteModel paciente = await _pacienteRepositorio.BuscarPorId(id);
            return Ok(paciente);
        }
        catch (Exception erro)
        {
            return BadRequest($"Não foi possívell buscar o paciente com o ID: {id}. Erro: {erro.Message}");
        }
    }

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
            //Capturamos o paciente pelo ID
            PacienteModel paciente = await _pacienteRepositorio.BuscarDocConvenioPorId(id);

            if (paciente.TemConvenio == false)
                return BadRequest("Este paciente não possui convênio");

            string caminho = paciente.ImgCarteiraDoConvenio;

            var imagem = new BuscaImagem(paciente);
        
            return imagem.BuscarImagem(caminho);
        }
        catch (Exception erro)
        {
            return BadRequest($"Não foi possível buscar o documento do convênio com ID: {id}. Erro: {erro.Message}");
        }
    }

    /// <summary>
    /// Buscar Imagem do Documento do Paciente
    /// </summary>
    /// <param name="id">ID do Paciente</param>
    /// <returns>A imagem do documento</returns>
    /// <response code="200">Imagem retornada com sucesso</response>
    [HttpGet("MostrarDoc/{id}")]
    [Authorize(Policy = "AdminAndDoctorRights")]
    public async Task<ActionResult<List<PacienteModel>>> BuscarDocPorId(int id)
    {
        try
        {
            PacienteModel paciente = await _pacienteRepositorio.BuscarDocPorId(id);
        
            string caminho = paciente.ImgDocumento;

            var imagem = new BuscaImagem(paciente);

            return imagem.BuscarImagem(caminho);
        }
        catch (Exception erro)
        {
            return BadRequest($"Não foi possível buscar o documento do paciente com o ID: {id}. Erro: {erro.Message}");
        }
    }

    /// <summary>
    /// Cadastrar um Paciente
    /// </summary>
    /// <param name="pacienteModel">Dados do Paciente</param>
    /// <returns>Paciente Cadastrado</returns>
    /// <response code="200">Paciente cadastrado com SUCESSO</response>
    [HttpPost]
    [Authorize(Policy = "AdminAndDoctorRights")]
    public async Task<ActionResult<PacienteModel>> Adicionar(PacienteModel pacienteModel)
    {
        try 
        {
            if (pacienteModel.TemConvenio == false && pacienteModel.DocConvenio.Length > 0)
            {
                return BadRequest("Não é possível adicionar uma carteira de convênio, caso o campo TemConvenio seja falso");
            }
            //É instanciado um novo objeto para a validação das imagens carregadas na requisição
            DocumentoImagemDto imagem = new DocumentoImagemDto();
            imagem.Doc = pacienteModel.Doc;
            imagem.DocConvenio = pacienteModel.DocConvenio;
            ValidaImagem validaImagem = new ValidaImagem(imagem, pacienteModel);
            var requestDtoValidado = validaImagem.ValidacaoImagem();

            if (requestDtoValidado)
            {
                PacienteModel paciente = await _pacienteRepositorio.Adicionar(pacienteModel);
                CadastroRequestDto novoPaciente = new CadastroRequestDto();

                novoPaciente.Nome = pacienteModel.Nome;
                novoPaciente.UserName = pacienteModel.Cpf;
                novoPaciente.Cpf = pacienteModel.Cpf;
                novoPaciente.Senha = pacienteModel.Senha;
                novoPaciente.DataNasc = pacienteModel.DataNasc;
                novoPaciente.Endereco = pacienteModel.Endereco;
                novoPaciente.Role = Role.Paciente;

                await _authenticationService.Register(novoPaciente);

                return Ok(paciente);
            }
            else
            {
                return BadRequest("Não foi possível cadastrar o paciente: Imagem inválida ou inexistente");
            }
        }
        catch (Exception erro)
        {
            return BadRequest($"Não foi possível cadastrar o paciente. Erro: {erro.Message}");
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
    [Authorize(Policy = "StandardRights")]
    public async Task<ActionResult<PacienteModel>> Atualizar([FromBody] PacienteModel pacienteModel, int id)
    {
        try
        {
            pacienteModel.Id = id;
            PacienteModel paciente = await _pacienteRepositorio.Atualizar(pacienteModel, id);
            return Ok(paciente);
        }
        catch (Exception erro)
        {
            return BadRequest($"Não foi possível atualizar o paciente com ID: {id}. Erro: {erro.Message}");
        }
    }

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
            PacienteModel paciente = await _pacienteRepositorio.BuscarPorId(id);
            ValidaImagem validaImagem = new ValidaImagem(documentoImagemDto, paciente);

            var requestDtoValidado = validaImagem.ValidacaoImagem();

            if (requestDtoValidado)
            {
                await _pacienteRepositorio.Atualizar(paciente, id);
                return Ok(documentoImagemDto);
            }

            return BadRequest("Não foi possível atualizar a imagem");
        }
        catch (Exception erro)
        {
            return BadRequest($"Não foi possível atualizar o documento do paciente com o ID: {id}. Erro: {erro.Message}");
        }

    }

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
            bool apagado = await _pacienteRepositorio.Apagar(id);
            return Ok(apagado);
        }
        catch (Exception erro)
        {
            return BadRequest($"Não foi possível apagar o paciente com o ID: {id}. Erro: {erro.Message}");
        }
    }
}
