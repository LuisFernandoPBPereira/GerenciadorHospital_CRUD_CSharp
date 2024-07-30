using GerenciadorHospital.Application.UseCases.Exame;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Exame;

[Tags("Exame")]
[Route("api/[controller]")]
[ApiController]
public class ExamePorIdController : ControllerBase
{
    private readonly ExamePorIdUseCase _buscarPorIdExameUseCase;

    public ExamePorIdController(ExamePorIdUseCase buscarPorIdExameUseCase)
    {
        _buscarPorIdExameUseCase = buscarPorIdExameUseCase;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var exame = await _buscarPorIdExameUseCase.Executar(id);

        return Ok(exame);
    }
}
