using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Mapper;

public static class ConvenioMapper
{
    public static ConvenioModel ToModel(ConvenioEntity convenio)
    {
        return new ConvenioModel
        {
            Id = convenio.Id,
            Nome = convenio.Nome,
            Preco = convenio.Preco
        };
    }

    public static ConvenioEntity ToDomain(ConvenioModel convenio)
    {
        return new ConvenioEntity
        {
            Id = convenio.Id,
            Nome = convenio.Nome,
            Preco = convenio.Preco
        };
    }
}
