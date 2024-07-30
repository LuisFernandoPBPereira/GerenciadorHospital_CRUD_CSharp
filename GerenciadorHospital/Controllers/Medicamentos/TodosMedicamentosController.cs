using GerenciadorHospital.Application.UseCases.Medicamento;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Medicamentos;

[Tags("Medicamento")]
[Route("api/[controller]")]
[ApiController]
public class TodosMedicamentosController : ControllerBase
{
    private readonly TodosMedicamentosUseCase _todosMedicamentosUseCase;

    public TodosMedicamentosController(TodosMedicamentosUseCase todosMedicamentosUseCase)
    {
        _todosMedicamentosUseCase = todosMedicamentosUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodos()
    {
        var medicamentos = await _todosMedicamentosUseCase.Executar();

        return Ok(medicamentos);
    }
}
