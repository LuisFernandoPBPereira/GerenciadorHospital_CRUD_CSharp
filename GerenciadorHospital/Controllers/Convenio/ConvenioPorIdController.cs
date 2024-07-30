using GerenciadorHospital.Application.UseCases.Convenio;
using GerenciadorHospital.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Convenio;

[Tags("Convênio")]
[Route("api/[controller]")]
[ApiController]
public class ConvenioPorIdController : ControllerBase
{
    private readonly ConvenioPorIdUseCase _buscarPorIdConvenioUseCase;

    public ConvenioPorIdController(ConvenioPorIdUseCase buscarPorIdConvenioUseCase)
    {
        _buscarPorIdConvenioUseCase = buscarPorIdConvenioUseCase;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var convenio = await _buscarPorIdConvenioUseCase.Executar(id);

            return Ok(convenio);
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
