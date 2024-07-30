using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Application.UseCases.Exame;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Exame;

[Tags("Exame")]
[Route("api/[controller]")]
[ApiController]
public class AtualizarExameController : ControllerBase
{
    private readonly AtualizarExameUseCase _atualizarExameUseCase;

    public AtualizarExameController(AtualizarExameUseCase atualizarExameUseCase)
    {
        _atualizarExameUseCase = atualizarExameUseCase;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarExame(int id, TipoExameRequestDto exameDto)
    {
        await _atualizarExameUseCase.Executar(id, exameDto);

        return Ok();
    }
}
