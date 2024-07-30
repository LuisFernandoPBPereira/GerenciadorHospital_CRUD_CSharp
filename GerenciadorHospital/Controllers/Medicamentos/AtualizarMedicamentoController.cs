using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Application.UseCases.Medicamento;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Medicamentos;

[Tags("Medicamento")]
[Route("api/[controller]")]
[ApiController]
public class AtualizarMedicamentoController : ControllerBase
{
    private readonly AtualizarMedicamentoUseCase _atualizarMedicamentoUseCase;

    public AtualizarMedicamentoController(AtualizarMedicamentoUseCase atualizarMedicamentoUseCase)
    {
        _atualizarMedicamentoUseCase = atualizarMedicamentoUseCase;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarMedicamento(int id, MedicamentoRequestDto medicamentoDto)
    {
        await _atualizarMedicamentoUseCase.Executar(id, medicamentoDto);

        return Ok();
    }
}
