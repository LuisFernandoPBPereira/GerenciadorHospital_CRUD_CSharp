using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Mapper;

public static class LaudoMapper
{
    public static LaudoModel ToModel(LaudoEntity laudo)
    {
        return new LaudoModel
        {
            Id = laudo.Id,
            Descricao = laudo.Descricao,
            DataCriacao = laudo.DataCriacao,
            MedicamentoId = laudo.MedicamentoId,
            MedicoId = laudo.MedicoId,
            PacienteId = laudo.PacienteId,
            RegistroConsultaModelId = laudo.RegistroConsultaModelId
        };
    }

    public static LaudoEntity ToDomain(LaudoModel laudo)
    {
        return new LaudoEntity
        {
            Descricao = laudo.Descricao,
            DataCriacao = laudo.DataCriacao,
            MedicamentoId = laudo.MedicamentoId,
            MedicoId = laudo.MedicoId,
            PacienteId = laudo.PacienteId,
            RegistroConsultaModelId = laudo.RegistroConsultaModelId
        };
    }
    
    public static IEnumerable<LaudoEntity> ToDomain(IEnumerable<LaudoModel> laudos)
    {
        var laudosEntity = new List<LaudoEntity>();

        foreach (var laudo in laudos)
        {
            var laudoEntity = new LaudoEntity
            {
                Descricao = laudo.Descricao,
                DataCriacao = laudo.DataCriacao,
                MedicamentoId = laudo.MedicamentoId,
                MedicoId = laudo.MedicoId,
                PacienteId = laudo.PacienteId,
                RegistroConsultaModelId = laudo.RegistroConsultaModelId
            };

            laudosEntity.Add(laudoEntity);
        }

        return laudosEntity;
    }
}
