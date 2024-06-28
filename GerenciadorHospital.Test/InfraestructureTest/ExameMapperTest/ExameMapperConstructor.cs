using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Infraestructure.Mapper;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Test.InfraestructureTest.ExameMapperTest;

public class ExameMapperConstructor
{
    [Fact]
    public void QuandoMapearParaExameDeDominioRetornarEntidade()
    {
        TipoExameModel tipoExameModel = new TipoExameModel();

        var tipoExameEntity = ExameMapper.ToDomain(tipoExameModel);

        Assert.NotNull(tipoExameEntity);
    }

    [Fact]
    public void QuandoMapearParaExameDeInfraRetornarModelo()
    {
        TipoExameEntity tipoExameEntity = new TipoExameEntity();

        var tipoExameModel = ExameMapper.ToModel(tipoExameEntity);

        Assert.NotNull(tipoExameModel);
    }
}
