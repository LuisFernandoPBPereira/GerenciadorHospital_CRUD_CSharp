using GerenciadorHospital.Application.UseCases.Medicamento;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Medicamentos;

[Tags("Medicamento")]
[Route("api/[controller]")]
[ApiController]
public class MedicamentoPorIdController : ControllerBase
{
    private readonly MedicamentoPorIdUseCase _medicamentoPorIdUseCase;

    public MedicamentoPorIdController(MedicamentoPorIdUseCase medicamentoPorIdUseCase)
    {
        _medicamentoPorIdUseCase = medicamentoPorIdUseCase;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var medicamento = await _medicamentoPorIdUseCase.Executar(id);

        return Ok(medicamento);
    }
}
