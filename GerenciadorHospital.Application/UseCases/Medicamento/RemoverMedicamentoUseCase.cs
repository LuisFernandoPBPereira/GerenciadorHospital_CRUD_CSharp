using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Medicamento;

public class RemoverMedicamentoUseCase
{
    private readonly IMedicamento _medicamento;

    public RemoverMedicamentoUseCase(IMedicamento medicamento)
    {
        _medicamento = medicamento;
    }

    public async Task<bool> Executar(int id)
    {
        var medicamentoRemovido = await _medicamento.Apagar(id);

        return medicamentoRemovido;
    }
}
