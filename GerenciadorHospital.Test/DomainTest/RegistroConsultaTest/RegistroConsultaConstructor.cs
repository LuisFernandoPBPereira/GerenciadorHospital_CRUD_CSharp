using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Test.DomainTest.RegistroConsultaTest;

public class RegistroConsultaConstructor
{
    [Fact]
    public void QuandoConstrutorValidoRetornarEntidade()
    {
        int id = 1;
        DateTime dataConsulta = DateTime.Now.AddMinutes(10);
        decimal valor = 100;
        DateTime dataRetorno = DateTime.Now;
        bool retorno = false;
        int pacienteId = 1;
        int medicoId = 1;
        int exameId = 1;

        RegistroConsultaEntity consulta = new RegistroConsultaEntity(id, dataConsulta, valor, dataRetorno, retorno, pacienteId, medicoId, exameId);

        Assert.NotNull(consulta);
    }
}
