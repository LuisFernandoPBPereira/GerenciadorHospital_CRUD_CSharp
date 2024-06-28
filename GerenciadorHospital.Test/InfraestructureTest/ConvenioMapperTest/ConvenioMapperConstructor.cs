using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Infraestructure.Mapper;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Test.InfraestructureTest.ConvenioMapperTest;

public class ConvenioMapperConstructor
{
    [Fact]
    public void QuandoMapearParaConvenioDeDominioRetornaEntidade()
    {
        ConvenioModel convenioModel = new ConvenioModel();
        
        var convenioDomain = ConvenioMapper.ToDomain(convenioModel);

        Assert.NotNull(convenioDomain);
    }

    [Fact]
    public void QuandoMapearParaConvenioDeInfraRetornarModelo()
    {
        ConvenioEntity convenioEntity = new ConvenioEntity();

        var convenioModel = ConvenioMapper.ToModel(convenioEntity);

        Assert.NotNull(convenioModel);
    }
}
