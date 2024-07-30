using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Mapper;

public static class ExameMapper
{

    public static TipoExameModel ToModel(TipoExameEntity exame)
    {
        return new TipoExameModel
        {
            Id = exame.Id,
            Nome = exame.Nome,
            MedicoId = exame.MedicoId,
            PacienteId = exame.PacienteId
        };
    }

    public static TipoExameEntity ToDomain(TipoExameModel exame)
    {
        return new TipoExameEntity
        {
            Id= exame.Id,
            Nome = exame.Nome,
            MedicoId = exame.MedicoId,
            PacienteId = exame.PacienteId
        };
    }
    
    public static IEnumerable<TipoExameEntity> ToDomain(IEnumerable<TipoExameModel> exames)
    {
        var examesEntity = new List<TipoExameEntity>();

        foreach (var exame in exames)
        {
            var exameEntity = new TipoExameEntity
            {
                Id = exame.Id,
                Nome = exame.Nome,
                MedicoId = exame.MedicoId,
                PacienteId = exame.PacienteId
            };

            examesEntity.Add(exameEntity);
        }

        return examesEntity;
    }
}
