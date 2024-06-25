using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Exceptions;
using GerenciadorHospital.Domain.Validations;

namespace GerenciadorHospital.Test.DomainTest.DomainValidationTest;

public class DomainValidationThrowsException
{
    [Fact]
    public void QuandoValidacaoNaoPassarLancaExcecao()
    {
        var user = new UsuarioEntity();
        var domainValidation = new DomainValidation();
        domainValidation.VerificaSeStringNulaVaziaOuComNumero(user.Nome, nameof(user.Nome));

        var exception = Record.Exception(() => domainValidation.VerificaErros());
        var domainException = (DomainException)exception;

        Assert.NotNull(exception);
        Assert.Contains($"{nameof(user.Nome)} inválido", domainException.Mensagem);
    }
}
