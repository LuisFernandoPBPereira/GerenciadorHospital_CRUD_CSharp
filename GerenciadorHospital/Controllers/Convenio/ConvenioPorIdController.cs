using GerenciadorHospital.Application.UseCases.Convenio;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Convenio;

[Tags("Convênio")]
[Route("api/[controller]")]
[ApiController]
public class ConvenioPorIdController : ControllerBase
{
    private readonly BuscarPorIdConvenioUseCase _buscarPorIdConvenioUseCase;

    public ConvenioPorIdController(BuscarPorIdConvenioUseCase buscarPorIdConvenioUseCase)
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
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
