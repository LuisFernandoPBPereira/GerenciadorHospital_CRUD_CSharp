using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Mapper;

public static class ConsultaMapper
{
    public static RegistroConsultaModel ToModel(RegistroConsultaEntity consulta)
    {
        return new RegistroConsultaModel
        {
            DataConsulta = consulta.DataConsulta,
            DataRetorno = consulta.DataRetorno,
            PacienteId = consulta.PacienteId,
            MedicoId = consulta.MedicoId,
            ExameId = consulta.ExameId,
            Valor = consulta.Valor,
            Retorno = consulta.Retorno
        };
    }

    public static RegistroConsultaEntity ToDomain(RegistroConsultaModel consulta)
    {
        return new RegistroConsultaEntity
        {
            DataConsulta = consulta.DataConsulta,
            DataRetorno = consulta.DataRetorno,
            PacienteId = consulta.PacienteId,
            MedicoId = consulta.MedicoId,
            ExameId = consulta.ExameId,
            Valor = consulta.Valor,
            Retorno = consulta.Retorno
        };
    }
}
