using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Infraestructure.Mapper;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Test.InfraestructureTest.ConsultaMapperTest;

public class ConsultaMapperConstructor
{
    [Fact]
    public void QuandoMapearParaConsultaDeDominioRetornarEntidade()
    {
        RegistroConsultaModel registroConsultaModel = new RegistroConsultaModel();

        var consultaEntity = ConsultaMapper.ToDomain(registroConsultaModel);

        Assert.NotNull(consultaEntity);
    }

    [Fact]
    public void QuandoMapearParaConsultaDeInfraRetornarModelo()
    {
        RegistroConsultaEntity registroConsultaEntity = new RegistroConsultaEntity();

        var consultaModel = ConsultaMapper.ToModel(registroConsultaEntity);

        Assert.NotNull(consultaModel);
    }
}
