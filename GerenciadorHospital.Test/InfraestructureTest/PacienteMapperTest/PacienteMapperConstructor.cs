using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Infraestructure.Mapper;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Test.InfraestructureTest.PacienteMapperTest;

public class PacienteMapperConstructor
{
    [Fact]
    public void QuandoMapearParaPacienteDeDominioRetornarEntidade()
    {
        PacienteModel pacienteModel = new PacienteModel();

        var pacienteEntity = PacienteMapper.ToDomain(pacienteModel);

        Assert.NotNull(pacienteEntity);
    }

    [Fact]
    public void QuandoMapearParaPacienteDeInfraRetornarModelo()
    {
        PacienteEntity pacienteEntity = new PacienteEntity();

        var pacienteModel = PacienteMapper.ToModel(pacienteEntity);

        Assert.NotNull(pacienteModel);
    }
}
