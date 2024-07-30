using GerenciadorHospital.Application.UseCases.Laudo;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Laudo;

[Tags("Laudo")]
[Route("api/[controller]")]
[ApiController]
public class LaudoPorIdController : ControllerBase
{
    private readonly LaudoPorIdUseCase _laudoPorIdUseCase;

    public LaudoPorIdController(LaudoPorIdUseCase laudoPorIdUseCase)
    {
        _laudoPorIdUseCase = laudoPorIdUseCase;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var laudo = await _laudoPorIdUseCase.Executar(id);

        return Ok(laudo);
    }
}
