using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Medicamento;

public class AtualizarMedicamentoUseCase
{
    private readonly IMedicamento _medicamento;

    public AtualizarMedicamentoUseCase(IMedicamento medicamento)
    {
        _medicamento = medicamento;
    }

    public async Task<MedicamentoEntity> Atualizar(MedicamentoRequestDto medicamentoDto)
    {
        var medicamentoEntity = new MedicamentoEntity(
            medicamentoDto.Nome,
            medicamentoDto.Composicao,
            medicamentoDto.DataFabricacao,
            medicamentoDto.DataValidade);

        var medicamentoAtualizado = await _medicamento.Atualizar(medicamentoEntity);

        return medicamentoAtualizado;
    }
}
