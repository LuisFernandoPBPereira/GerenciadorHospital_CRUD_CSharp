using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Mapper;

public static class MedicamentoMapper
{
    public static MedicamentoPacienteModel ToModel(MedicamentoEntity medicamento)
    {
        return new MedicamentoPacienteModel
        {
            Nome = medicamento.Nome,
            Composicao = medicamento.Composicao,
            DataFabricacao = medicamento.DataFabricacao,
            DataValidade = medicamento.DataValidade
        };
    }

    public static MedicamentoEntity ToDomain(MedicamentoPacienteModel medicamento)
    {
        return new MedicamentoEntity
        {
            Nome = medicamento.Nome,
            Composicao = medicamento.Composicao,
            DataFabricacao = medicamento.DataFabricacao,
            DataValidade = medicamento.DataValidade
        };
    }
}
