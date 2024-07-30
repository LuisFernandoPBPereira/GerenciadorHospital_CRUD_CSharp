using GerenciadorHospital.Application.UseCases.Laudo;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Laudo;

[Tags("Laudo")]
[Route("api/[controller]")]
[ApiController]
public class TodosLaudosController : ControllerBase
{
    private readonly TodosLaudosUseCase _todosLaudosUseCase;

    public TodosLaudosController(TodosLaudosUseCase todosLaudosUseCase)
    {
        _todosLaudosUseCase = todosLaudosUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodos()
    {
        var laudos = await _todosLaudosUseCase.Executar();

        return Ok(laudos);
    }
}
