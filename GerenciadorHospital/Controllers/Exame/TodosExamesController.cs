using GerenciadorHospital.Application.UseCases.Exame;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Exame;

[Tags("Exame")]
[Route("api/[controller]")]
[ApiController]
public class TodosExamesController : ControllerBase
{
    private readonly TodosExamesUseCase _buscarTodosExamesUseCase;

    public TodosExamesController(TodosExamesUseCase buscarTodosExamesUseCase)
    {
        _buscarTodosExamesUseCase = buscarTodosExamesUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodos()
    {
        var exames = await _buscarTodosExamesUseCase.Executar();

        return Ok(exames);
    }
}
