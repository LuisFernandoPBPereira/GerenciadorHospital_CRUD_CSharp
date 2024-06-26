using GerenciadorHospital.Domain.Exceptions;
using GerenciadorHospital.Domain.Validations;

namespace GerenciadorHospital.Test.DomainTest.DomainValidationTest;

public class DomainValidationThrowsException
{
    [Theory]
    [InlineData("", "teste")]
    [InlineData(null, "teste")]
    [InlineData("teste123", "teste")]
    public void QuandoValidacaoDeStringVaziaNulaOuComNumeroNaoPassarLancaExcecao(string campo, string nomeDoCampo)
    {
        DomainValidation domainValidation = new DomainValidation();
        string mensagem = $"{nomeDoCampo} inválido";

        domainValidation.VerificaSeStringNulaVaziaOuComNumero(campo, nomeDoCampo);

        var exception = Assert.Throws<DomainException>(() =>
        {
            domainValidation.VerificaErros();
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData("", "teste")]
    [InlineData(null, "teste")]
    public void QuandoValidacaoDeStringVaziaoOuNula(string? campo, string nomeDoCampo)
    {
        DomainValidation domainValidation = new DomainValidation();
        string mensagem = $"{nomeDoCampo} inválido";

        domainValidation.VerificaSeStringNulaVazia(campo, nomeDoCampo);

        var exception = Assert.Throws<DomainException>(() =>
        {
            domainValidation.VerificaErros();
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }
}
