using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Application.UseCases.Convenio;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Convenio;

[Tags("Convênio")]
[Route("api/[controller]")]
[ApiController]
public class AdicionarConvenioController : ControllerBase
{
    private readonly AdicionarConvenioUseCase _adicionarConvenioUseCase;

    public AdicionarConvenioController(AdicionarConvenioUseCase adicionarConvenioUseCase)
    {
        _adicionarConvenioUseCase = adicionarConvenioUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarConvenio([FromBody] ConvenioRequestDto convenioDto)
    {
        try
        {
            var convenio = await _adicionarConvenioUseCase.Adicionar(convenioDto);

            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
