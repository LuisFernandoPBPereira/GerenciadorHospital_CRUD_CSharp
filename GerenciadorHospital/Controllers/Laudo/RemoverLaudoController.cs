using GerenciadorHospital.Application.UseCases.Laudo;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Laudo;

[Tags("Laudo")]
[Route("api/[controller]")]
[ApiController]
public class RemoverLaudoController : ControllerBase
{
    private readonly RemoverLaudoUseCase _removerLaudoUseCase;

    public RemoverLaudoController(RemoverLaudoUseCase removerLaudoUseCase)
    {
        _removerLaudoUseCase = removerLaudoUseCase;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverLaudo(int id)
    {
        var laudoApagado = await _removerLaudoUseCase.Executar(id);

        return Ok(laudoApagado);
    }
}
