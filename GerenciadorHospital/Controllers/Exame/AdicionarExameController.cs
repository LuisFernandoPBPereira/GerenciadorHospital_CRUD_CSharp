using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Application.UseCases.Exame;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Exame;

[Tags("Exame")]
[Route("api/[controller]")]
[ApiController]
public class AdicionarExameController : ControllerBase
{
    private readonly AdicionarExameUseCase _adiionarExameUseCase;

    public AdicionarExameController(AdicionarExameUseCase adiionarExameUseCase)
    {
        _adiionarExameUseCase = adiionarExameUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarExame([FromBody] TipoExameRequestDto exameDto)
    {
        await _adiionarExameUseCase.Executar(exameDto);

        return Created();
    }
}
