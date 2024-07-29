using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Mapper;

public static class ConvenioMapper
{
    public static ConvenioModel ToModel(ConvenioEntity convenio)
    {
        return new ConvenioModel
        {
            Nome = convenio.Nome,
            Preco = convenio.Preco
        };
    }

    public static ConvenioEntity ToDomain(ConvenioModel convenio)
    {
        return new ConvenioEntity
        {
            Nome = convenio.Nome,
            Preco = convenio.Preco
        };
    }
    
    public static IEnumerable<ConvenioEntity> ToDomain(IEnumerable<ConvenioModel> convenios)
    {
        List<ConvenioEntity> conveniosEntity = [];

        foreach (var convenio in convenios) 
        {
            conveniosEntity.Add(new ConvenioEntity { Nome = convenio.Nome, Preco = convenio.Preco });
        }

        return conveniosEntity;
    }
}
