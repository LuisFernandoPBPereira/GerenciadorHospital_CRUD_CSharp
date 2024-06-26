using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Exceptions;

namespace GerenciadorHospital.Test.DomainTest.ConvenioTest;

public class ConvenioConstructor
{
    [Theory]
    [InlineData(1, "convenio", 100)]
    public void QuandoConstrutorValidoRetornarEntidade(int id, string nome, decimal preco)
    {
        ConvenioEntity convenio = new ConvenioEntity(id, nome, preco);

        Assert.NotNull(convenio);
    }
    
    [Theory]
    [InlineData(1, "", -100)]
    public void QuandoConstrutorInvalidoLancarExcecao(int id, string nome, decimal preco)
    {
        Assert.Throws<DomainException>(() => 
        { 
            ConvenioEntity convenio = new ConvenioEntity(id, nome, preco);
        });
    }

    [Theory]
    [InlineData(0, "convenio", 100)]
    public void QuandoIdInvalidoLancarExcecaoComMensagem(int id, string nome, decimal preco)
    {
        string mensagem = "Id inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            ConvenioEntity convenio = new ConvenioEntity(id, nome, preco);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "", 100)]
    [InlineData(1, "convenio32434", 100)]
    [InlineData(1, null, 100)]
    public void QuandoNomeInvalidoLancarExcecaoComMensagem(int id, string nome, decimal preco)
    {
        string mensagem = "Nome inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            ConvenioEntity convenio = new ConvenioEntity(id, nome, preco);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "convenio", -100)]
    public void QuandoPrecoInvalidoLancarExcecaoComMensagem(int id, string nome, decimal preco)
    {
        string mensagem = "Preço não pode ser negativo";

        var exception = Assert.Throws<DomainException>(() =>
        {
            ConvenioEntity convenio = new ConvenioEntity(id, nome, preco);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }
}
