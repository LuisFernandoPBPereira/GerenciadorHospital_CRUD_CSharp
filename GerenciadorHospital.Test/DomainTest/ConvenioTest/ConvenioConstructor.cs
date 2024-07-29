//using GerenciadorHospital.Domain.Entites;
//using GerenciadorHospital.Domain.Exceptions;

//namespace GerenciadorHospital.Test.DomainTest.ConvenioTest;

//public class ConvenioConstructor
//{
//    [Theory]
//    [InlineData("convenio", 100)]
//    public void QuandoConstrutorValidoRetornarEntidade(string nome, decimal preco)
//    {
//        ConvenioEntity convenio = new ConvenioEntity(nome, preco);

//        Assert.NotNull(convenio);
//    }
    
//    [Fact]
//    public void QuandoConstrutorVazioRetornarEntidadeComStringsVazias()
//    {
//        ConvenioEntity convenio = new ConvenioEntity();

//        Assert.Equal(string.Empty, convenio.Nome);
//    }
    
//    [Theory]
//    [InlineData("", -100)]
//    public void QuandoConstrutorInvalidoLancarExcecao(string nome, decimal preco)
//    {
//        Assert.Throws<DomainException>(() => 
//        { 
//            ConvenioEntity convenio = new ConvenioEntity(nome, preco);
//        });
//    }

//    [Theory]
//    [InlineData("", 100)]
//    [InlineData("convenio32434", 100)]
//    [InlineData(null, 100)]
//    public void QuandoNomeInvalidoLancarExcecaoComMensagem(string nome, decimal preco)
//    {
//        string mensagem = "Nome inválido";

//        var exception = Assert.Throws<DomainException>(() =>
//        {
//            ConvenioEntity convenio = new ConvenioEntity(nome, preco);
//        });
//        Assert.Contains(mensagem, exception.Mensagem);
//    }

//    [Theory]
//    [InlineData("convenio", -100)]
//    public void QuandoPrecoInvalidoLancarExcecaoComMensagem(string nome, decimal preco)
//    {
//        string mensagem = "Preço não pode ser negativo";

//        var exception = Assert.Throws<DomainException>(() =>
//        {
//            ConvenioEntity convenio = new ConvenioEntity(nome, preco);
//        });
//        Assert.Contains(mensagem, exception.Mensagem);
//    }
//}
