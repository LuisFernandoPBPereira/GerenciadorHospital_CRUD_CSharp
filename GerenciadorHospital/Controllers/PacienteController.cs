using GerenciadorHospital.Dto;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
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

    [HttpGet]
    public async Task<ActionResult<List<PacienteModel>>> BuscarTodosPacientes()
    {
        List<PacienteModel> pacientes = await _pacienteRepositorio.BuscarTodosPacientes();
        return Ok(pacientes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<PacienteModel>>> BuscarPorId(int id)
    {
        PacienteModel paciente = await _pacienteRepositorio.BuscarPorId(id);
        return Ok(paciente);
    }

    //Método GET para retornar o documento da carteira do convênio
    [HttpGet("MostrarDocConvenio/{id}")]
    public async Task<ActionResult<List<PacienteModel>>> BuscarDocConvenioPorId(int id)
    {
        //Capturamos o paciente pelo ID
        PacienteModel paciente = await _pacienteRepositorio.BuscarDocConvenioPorId(id);

        //Se o paciente não tiver uma imagem salva, retorna uma BadRequest
        if (paciente.ImgCarteiraDoConvenio == null)
        {
            return BadRequest("Este paciente não possui foto da carteira do convênio");
        }
        //Caso o paciente não tenha convênio, retorna outra BadRequest
        else if (paciente.TemConvenio == false)
        {
            return BadRequest("Este paciente não possui convênio");

        }

        var caminho = paciente.ImgCarteiraDoConvenio;

        if(caminho is null)
        {
            return BadRequest("Este paciente não possui carteira do convênio");
        }

        Byte[] b = System.IO.File.ReadAllBytes($"{caminho}");
        return File(b, "image/png");
    }
    
    //Método GET para retornar o documento do paciente
    [HttpGet("MostrarDoc/{id}")]
    public async Task<ActionResult<List<PacienteModel>>> BuscarDocPorId(int id)
    {
        PacienteModel paciente = await _pacienteRepositorio.BuscarDocPorId(id);
        var caminho = paciente.ImgDocumento;

        Byte[] b = System.IO.File.ReadAllBytes($"{caminho}");
        return File(b, "image/png");
    }

    //Método POST com requisição pelo body para a criação do paciente de forma assíncrona
    [HttpPost]
    public async Task<ActionResult<PacienteModel>> Adicionar(PacienteResquestDto requestDto)
    {
        if (requestDto.TemConvenio)
        {
            if (requestDto.DocConvenio == null || requestDto.DocConvenio.Length == 0)
            {
                return BadRequest("Nenhuma foto de convênio foi carregada");
            }
            Guid guidDocConvenio = Guid.NewGuid();
            
            var caminhoConvenio = Path.Combine("Imagens/", $"{guidDocConvenio + requestDto.DocConvenio.FileName}");
            
            requestDto.ImgCarteiraDoConvenio = caminhoConvenio;

            using (var stream = new FileStream(caminhoConvenio, FileMode.Create))
            {
                await requestDto.DocConvenio.CopyToAsync(stream);
            }
        }

        //Se as fotos não forem carregadas, será retornado uma BadRequest
        if (requestDto.Doc == null || requestDto.Doc.Length == 0)
        {
            return BadRequest("Nenhuma foto de documento foi carregada");
        }
        //Geramos um novo guid para deixar a foto com id único
        Guid guidDoc = Guid.NewGuid();
        
        //Passamos os caminhos das imagens
        var caminhoDoc = Path.Combine("Imagens/", $"{guidDoc + requestDto.Doc.FileName}");

        //Todos pacientes recebem a imagem de documento

        using (var stream = new FileStream(caminhoDoc, FileMode.Create))
        {
            await requestDto.Doc.CopyToAsync(stream);
        }

        //Se o paciente tem comvênio, ele recebe a imagem da carteira do convênio

        requestDto.ImgDocumento = caminhoDoc;
        
        PacienteModel paciente = await _pacienteRepositorio.Adicionar(requestDto);
        
        return Ok(paciente);
    }

    //Método PUT com requisição pelo body para a atualização do paciente de forma assíncrona
    [HttpPut("{id}")]
    public async Task<ActionResult<PacienteModel>> Atualizar([FromBody] PacienteModel pacienteModel, int id)
    {
        pacienteModel.Id = id;
        PacienteModel paciente = await _pacienteRepositorio.Atualizar(pacienteModel, id);
        return Ok(paciente);
    }

    //Método DELETE que busca o paciente pelo ID para deletar o paciente
    [HttpDelete("{id}")]
    public async Task<ActionResult<PacienteModel>> Apagar(int id)
    {
        bool apagado = await _pacienteRepositorio.Apagar(id);
        return Ok(apagado);
    }
}
