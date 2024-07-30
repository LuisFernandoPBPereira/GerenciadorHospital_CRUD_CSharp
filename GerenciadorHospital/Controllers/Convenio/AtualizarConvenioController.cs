using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Application.UseCases.Convenio;
using GerenciadorHospital.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Convenio;

[Tags("Convênio")]
[Route("api/[controller]")]
[ApiController]
public class AtualizarConvenioController : ControllerBase
{
    private readonly AtualizarConvenioUseCase _atualizarConvenioUseCase;

    public AtualizarConvenioController(AtualizarConvenioUseCase atualizarConvenioUseCase)
    {
        _atualizarConvenioUseCase = atualizarConvenioUseCase;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarConvenio(int id, ConvenioRequestDto convenioDto)
    {
        try
        {
            await _atualizarConvenioUseCase.Atualizar(id, convenioDto);
            return Ok();
        }
        catch (DomainException ex)
        {
            return BadRequest(ex.Mensagem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
