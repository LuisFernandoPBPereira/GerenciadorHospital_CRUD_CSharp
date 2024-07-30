using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Application.UseCases.Medicamento;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Medicamentos;

[Tags("Medicamento")]
[Route("api/[controller]")]
[ApiController]
public class AdicionarMedicamentoController : ControllerBase
{
    private readonly AdicionarMedicamentoUseCase _adicionarMedicamentoUseCase;

    public AdicionarMedicamentoController(AdicionarMedicamentoUseCase adicionarMedicamentoUseCase)
    {
        _adicionarMedicamentoUseCase = adicionarMedicamentoUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarMedicamento([FromBody] MedicamentoRequestDto medicamentoDto)
    {
        await _adicionarMedicamentoUseCase.Executar(medicamentoDto);

        return Created();
    }
}
