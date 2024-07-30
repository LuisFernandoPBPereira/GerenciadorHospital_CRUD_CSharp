using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Mapper;

public static class MedicamentoMapper
{
    public static MedicamentoPacienteModel ToModel(MedicamentoEntity medicamento)
    {
        return new MedicamentoPacienteModel
        {
            Id = medicamento.Id,
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
            Id = medicamento.Id,
            Nome = medicamento.Nome,
            Composicao = medicamento.Composicao,
            DataFabricacao = medicamento.DataFabricacao,
            DataValidade = medicamento.DataValidade
        };
    }
    
    public static IEnumerable<MedicamentoEntity> ToDomain(IEnumerable<MedicamentoPacienteModel> medicamentos)
    {
        var medicamentosEntity = new List<MedicamentoEntity>();

        foreach (var medicamento in medicamentos)
        {
            var medicamentoEntity = new MedicamentoEntity
            {
                Id = medicamento.Id,
                Nome = medicamento.Nome,
                Composicao = medicamento.Composicao,
                DataFabricacao = medicamento.DataFabricacao,
                DataValidade = medicamento.DataValidade
            };

            medicamentosEntity.Add(medicamentoEntity);
        }

        return medicamentosEntity;
    }
}
