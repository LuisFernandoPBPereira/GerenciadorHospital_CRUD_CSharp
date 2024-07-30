using GerenciadorHospital.Application.DTOs.Responses;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Medicamento;

public class TodosMedicamentosUseCase
{
    private readonly IMedicamento _medicamento;

    public TodosMedicamentosUseCase(IMedicamento medicamento)
    {
        _medicamento = medicamento;
    }

    public async Task<IEnumerable<MedicamentoResponseDto>> Executar()
    {
        var medicamentos = await _medicamento.BuscarTodos();
        var medicamentosDto = new List<MedicamentoResponseDto>();

        foreach (var medicamento in medicamentos)
        {
            var responseMedicamento = new MedicamentoResponseDto(medicamento);
            medicamentosDto.Add(responseMedicamento);
        }

        return medicamentosDto;
    }
}
