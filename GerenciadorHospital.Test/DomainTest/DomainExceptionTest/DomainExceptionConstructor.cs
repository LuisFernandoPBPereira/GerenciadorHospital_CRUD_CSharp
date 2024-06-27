using GerenciadorHospital.Domain.Exceptions;

namespace GerenciadorHospital.Test.DomainTest.DomainExceptionTest;

public class DomainExceptionConstructor
{
    [Fact]
    public void QuandoConstrutorValidoMensagemDeveSerAtribuida()
    {
        string mensagem = "mensagem teste";
        DomainException domainException = new DomainException(mensagem);

        Assert.Equal(mensagem, domainException.Mensagem);
    }
    
    [Fact]
    public void QuandoConstrutorVazioMensagemDeveSerAtribuida()
    {
        DomainException domainException = new DomainException();

        Assert.NotNull(domainException.Mensagem);
    }
}
