using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Exceptions;

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
    
    [Fact]
    public void QuandoConstrutorVazioRetornaEntidadeComStringsVazias()
    {
        TipoExameEntity tipoExameEntity = new TipoExameEntity();

        Assert.Equal(string.Empty, tipoExameEntity.Nome);
    }

    [Fact]
    public void QuandoConstrutorInvalidoLancarExcecao()
    {
        int id = 1;
        string? nome = null;
        int pacienteId = 1;
        int medicoId = 1;

        Assert.Throws<DomainException>(() => { TipoExameEntity tipoExameEntity = new TipoExameEntity(id, nome, pacienteId, medicoId); });
    }

    [Theory]
    [InlineData(0, "Hemograma", 1, 1)]
    [InlineData(1, "Hemograma", 1, 0)]
    [InlineData(1, "Hemograma", 0, 1)]
    public void QuandoIdInvalidoLancarExcecaoComMensagem(int id, string nome, int pacienteId, int medicoId)
    {
        string mensagem = "Id inválido";

        var exception = Assert.Throws<DomainException>(() => { TipoExameEntity tipoExameEntity = new TipoExameEntity(id, nome, pacienteId, medicoId); });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Fact]
    public void QuandoNomeInvalidoLancarExcecaoComMensagem()
    {
        int id = 1;
        string? nome = null;
        int pacienteId = 1;
        int medicoId = 1;

        string mensagem = "Nome inválido";

        var exception = Assert.Throws<DomainException>(() => { TipoExameEntity tipoExameEntity = new TipoExameEntity(id, nome, pacienteId, medicoId); });
        Assert.Contains(mensagem, exception.Mensagem);
    }

}
