using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Medicamento;

public class AdicionarMedicamentoUseCase
{
    private readonly IMedicamento _medicamento;

    public AdicionarMedicamentoUseCase(IMedicamento medicamento)
    {
        _medicamento = medicamento;
    }

    public async Task<MedicamentoEntity> Adicionar(MedicamentoRequestDto medicamentoDto)
    {
        var medicamentoEntity = new MedicamentoEntity(
            medicamentoDto.Nome,
            medicamentoDto.Composicao,
            medicamentoDto.DataFabricacao,
            medicamentoDto.DataValidade);

        var medicamentoAdicionado = await _medicamento.Adicionar(medicamentoEntity);

        return medicamentoAdicionado;
    }
}
