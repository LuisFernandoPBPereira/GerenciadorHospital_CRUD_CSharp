using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Medicamento;

public class BuscarPorIdMedicamentoUseCase
{
    private readonly IMedicamento _medicamento;

    public BuscarPorIdMedicamentoUseCase(IMedicamento medicamento)
    {
        _medicamento = medicamento;
    }

    public async Task<MedicamentoEntity> BuscarPorId(int id)
    {
        var medicamentoEntity = await _medicamento.BuscarPorId(id);

        return medicamentoEntity;
    }
}
