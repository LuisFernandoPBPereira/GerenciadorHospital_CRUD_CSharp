using GerenciadorHospital.Application.UseCases.Exame;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Exame;

[Tags("Exame")]
[Route("api/[controller]")]
[ApiController]
public class RemoverExameController : ControllerBase
{
    private readonly RemoverExameUseCase _removerExameUseCase;

    public RemoverExameController(RemoverExameUseCase removerExameUseCase)
    {
        _removerExameUseCase = removerExameUseCase;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverExame(int id)
    {
        var exameApagado = await _removerExameUseCase.Remover(id);

        return Ok(exameApagado);
    }
}
