using GerenciadorHospital.Application.DTOs.Responses;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Medicamento;

public class MedicamentoPorIdUseCase
{
    private readonly IMedicamento _medicamento;

    public MedicamentoPorIdUseCase(IMedicamento medicamento)
    {
        _medicamento = medicamento;
    }

    public async Task<MedicamentoResponseDto> Executar(int id)
    {
        var medicamentoEntity = await _medicamento.BuscarPorId(id);
        var responseMedicamento = new MedicamentoResponseDto(medicamentoEntity);
        
        return responseMedicamento;
    }
}
