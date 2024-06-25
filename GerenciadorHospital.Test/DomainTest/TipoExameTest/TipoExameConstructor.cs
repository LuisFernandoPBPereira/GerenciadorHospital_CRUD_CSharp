using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Test.DomainTest.TipoExameTest;

public class TipoExameConstructor
{
    [Fact]
    public void QuandoConstrutorValidoRetornaEntidade()
    {
        int id = 1;
        string nome = "Hemograma";
        int pacienteId = 1;
        int medicoId = 1;

        TipoExameEntity tipoExameEntity = new TipoExameEntity(id, nome, pacienteId, medicoId);

        Assert.NotNull(tipoExameEntity);
    }
}
