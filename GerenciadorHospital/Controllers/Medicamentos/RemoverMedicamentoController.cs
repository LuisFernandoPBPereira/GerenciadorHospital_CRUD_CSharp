using GerenciadorHospital.Application.UseCases.Medicamento;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Medicamentos;

[Tags("Medicamento")]
[Route("api/[controller]")]
[ApiController]
public class RemoverMedicamentoController : ControllerBase
{
    private readonly RemoverMedicamentoUseCase _removerMedicamentoUseCase;

    public RemoverMedicamentoController(RemoverMedicamentoUseCase removerMedicamentoUseCase)
    {
        _removerMedicamentoUseCase = removerMedicamentoUseCase;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverMedicamento(int id)
    {
        var medicamentoApagado = await _removerMedicamentoUseCase.Executar(id);

        return Ok(medicamentoApagado);
    }
}
