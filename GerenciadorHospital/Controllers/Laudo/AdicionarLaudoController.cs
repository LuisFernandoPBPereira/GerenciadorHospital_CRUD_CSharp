using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Application.UseCases.Laudo;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Laudo;

[Tags("Laudo")]
[Route("api/[controller]")]
[ApiController]
public class AdicionarLaudoController : ControllerBase
{
    private readonly AdicionarLaudoUseCase _adicionarLaudoUseCase;

    public AdicionarLaudoController(AdicionarLaudoUseCase adicionarLaudoUseCase)
    {
        _adicionarLaudoUseCase = adicionarLaudoUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarLaudo([FromBody] LaudoRequestDto laudoDto)
    {
        await _adicionarLaudoUseCase.Executar(laudoDto);

        return Created();
    }
}
