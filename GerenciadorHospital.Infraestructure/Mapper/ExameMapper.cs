using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Mapper;

public static class ExameMapper
{
    public static TipoExameModel ToModel(TipoExameEntity exame)
    {
        return new TipoExameModel
        {
            MedicoId = exame.MedicoId,
            PacienteId = exame.PacienteId
        };
    }

    public static TipoExameEntity ToDomain(TipoExameModel exame)
    {
        return new TipoExameEntity
        {
            MedicoId = exame.MedicoId,
            PacienteId = exame.PacienteId
        };
    }
}
