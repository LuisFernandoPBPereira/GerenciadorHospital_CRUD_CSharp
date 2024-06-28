using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Infraestructure.Mapper;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Test.InfraestructureTest.LaudoMapperTest;

public class LaudoMapperConstructor
{
    [Fact]
    public void QuandoMapearParaLaudoDeDominioRetornarEntidade()
    {
        LaudoModel laudoModel = new LaudoModel();

        var laudoEntity = LaudoMapper.ToDomain(laudoModel);

        Assert.NotNull(laudoEntity);
    }

    [Fact]
    public void QuandoMapearParaLaudoDeInfraRetornarModelo()
    {
        LaudoEntity laudoEntity = new LaudoEntity();
    
        var laudoModel = LaudoMapper.ToModel(laudoEntity);

        Assert.NotNull(laudoModel);
    }
}
