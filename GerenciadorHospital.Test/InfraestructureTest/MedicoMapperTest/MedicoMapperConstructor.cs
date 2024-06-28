using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Infraestructure.Mapper;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Test.InfraestructureTest.MedicoMapperTest;

public class MedicoMapperConstructor
{
    [Fact]
    public void QuandoMapearParaMedicoDeDominioRetornarEntidade()
    {
        MedicoModel medicoModel = new MedicoModel();

        var medicoEntity = MedicoMapper.ToDomain(medicoModel);

        Assert.NotNull(medicoEntity);
    }

    [Fact]
    public void QuandoMapearParaMedicoDeInfraRetornarModelo()
    {
        MedicoEntity medicoEntity = new MedicoEntity();

        var medicoModel = MedicoMapper.ToModel(medicoEntity);

        Assert.NotNull(medicoModel);
    }
}
