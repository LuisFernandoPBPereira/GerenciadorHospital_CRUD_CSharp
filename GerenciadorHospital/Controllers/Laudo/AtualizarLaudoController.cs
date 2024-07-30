using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Application.UseCases.Laudo;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Laudo;

[Tags("Laudo")]
[Route("api/[controller]")]
[ApiController]
public class AtualizarLaudoController : ControllerBase
{
    private readonly AtualizarLaudoUseCase _atualizarLaduoUseCase;

    public AtualizarLaudoController(AtualizarLaudoUseCase atualizarLaduoUseCase)
    {
        _atualizarLaduoUseCase = atualizarLaduoUseCase;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarLaudo(int id, LaudoRequestDto laudoDto)
    {
        await _atualizarLaduoUseCase.Executar(id, laudoDto);

        return Ok();
    }
}
