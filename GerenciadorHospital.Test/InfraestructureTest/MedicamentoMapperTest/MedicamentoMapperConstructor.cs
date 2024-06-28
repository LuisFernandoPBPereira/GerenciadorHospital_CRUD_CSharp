using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Infraestructure.Mapper;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Test.InfraestructureTest.MedicamentoMapperTest;

public class MedicamentoMapperConstructor
{
    [Fact]
    public void QuandoMapearParaMedicamentoDeDominioRetornarEntidade()
    {
        MedicamentoPacienteModel medicamento = new MedicamentoPacienteModel();

        var medicamentoEntity = MedicamentoMapper.ToDomain(medicamento);

        Assert.NotNull(medicamentoEntity);
    }

    [Fact]
    public void QuandoMapearParaMedicamentoDeInfraRetornarModelo()
    {
        MedicamentoEntity medicamentoEntity = new MedicamentoEntity();

        var medicamentoModel = MedicamentoMapper.ToModel(medicamentoEntity);

        Assert.NotNull(medicamentoModel);
    }
}
