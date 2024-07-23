using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Mapper;

public static class LaudoMapper
{
    public static LaudoModel ToModel(LaudoEntity laudo)
    {
        return new LaudoModel
        {
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
}
