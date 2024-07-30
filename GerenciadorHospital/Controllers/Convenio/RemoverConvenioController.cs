using GerenciadorHospital.Application.UseCases.Convenio;
using GerenciadorHospital.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Convenio;

[Tags("Convênio")]
[Route("api/[controller]")]
[ApiController]
public class RemoverConvenioController : ControllerBase
{
    private readonly RemoverConvenioUseCase _removerConvenioUseCase;

    public RemoverConvenioController(RemoverConvenioUseCase removerConvenioUseCase)
    {
        _removerConvenioUseCase = removerConvenioUseCase;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverConvenio(int id)
    {
        try
        {
            var convenioApagado = await _removerConvenioUseCase.Remover(id);
            
            return Ok(convenioApagado);
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
