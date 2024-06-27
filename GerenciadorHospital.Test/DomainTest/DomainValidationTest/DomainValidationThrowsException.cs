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
    public void QuandoValidacaoDeStringVaziaoOuNulaNaoPassarLancaExcecao(string? campo, string nomeDoCampo)
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

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("0sdfgdsfg123")]
    public void QuandoValidacaoDeCpfNaoPassarLancarExcecao(string cpf)
    {
        DomainValidation domainValidation = new DomainValidation();

        string mensagem = "CPF inválido";

        domainValidation.VerificaCpf(cpf);

        var exception = Assert.Throws<DomainException>(() =>
        {
            domainValidation.VerificaErros();
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData("1800-01-01")]
    [InlineData("1900-01-01")]
    public void QuandoValidacaoDeDataDeNascimentoMuitoAntigaNaoPassarLancarExcecao(DateTime dataNasc)
    {
        DomainValidation domainValidation = new DomainValidation();
        string mensagem = "Data de nascimento inválida";

        domainValidation.VerificaDataDeNascimento(dataNasc);

        var exception = Assert.Throws<DomainException>(() =>
        {
            domainValidation.VerificaErros();
        });
        Assert.Contains(mensagem, exception.Mensagem);
        Assert.True(dataNasc <= DateTime.Parse("1900-01-01"));
    }
    
    [Theory]
    [InlineData("2025-01-01")]
    [InlineData("2024-06-27")]
    public void QuandoValidacaoDeDataDeNascimentoNoFuturoNaoPassarLancarExcecao(DateTime dataNasc)
    {
        DomainValidation domainValidation = new DomainValidation();
        string mensagem = "Data de nascimento inválida";

        domainValidation.VerificaDataDeNascimento(dataNasc);

        var exception = Assert.Throws<DomainException>(() =>
        {
            domainValidation.VerificaErros();
        });
        Assert.Contains(mensagem, exception.Mensagem);
        Assert.True(dataNasc.Date >= DateTime.Now.Date);
    }

    [Theory]
    [InlineData("1990-01-01", "teste")]
    public void QuandoValidacaoDeDataQueNaoPodeSerNoPassadoNaoPassarLancarExcecao(DateTime dataPassada, string nomeDoCampo)
    {
        DomainValidation domainValidation = new DomainValidation();
        string mensagem = $"{nomeDoCampo} inválida";

        domainValidation.VerificaDataNaoPodeSerNoPassado(dataPassada, nomeDoCampo);

        var exception = Assert.Throws<DomainException>(() =>
        {
            domainValidation.VerificaErros();
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("senha")]
    public void QuandoValidacaoDeSenhaNaoPassarLancarExcecao(string senha)
    {
        DomainValidation domainValidation = new DomainValidation();
        string mensagem = "A senha deve conter no mínimo 6 caracteres, no mínimo 1 letra maiúscula, no mínimo 1 número e no mínimo 1 caractere especial";

        domainValidation.VerificaSenha(senha);

        var exception = Assert.Throws<DomainException>(() =>
        {
            domainValidation.VerificaErros();
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(-100)]
    public void QuandoValidacaoDePrecoNaoPassarLancarExcecao(decimal preco)
    {
        DomainValidation domainValidation = new DomainValidation();
        string mensagem = "Preço não pode ser negativo";

        domainValidation.VerificaPreco(preco);

        var exception = Assert.Throws<DomainException>(() =>
        {
            domainValidation.VerificaErros();
        });
        Assert.Contains(mensagem, exception.Mensagem);
        Assert.True(preco < 0);
    }

    [Theory]
    [InlineData("0000000000000")]
    [InlineData("0000000000")]
    public void QuandoValidacaoCrmLenghtMaiorQue10NaoPassarLancarExcecao(string crm)
    {
        DomainValidation domainValidation = new DomainValidation();
        string mensagem = "CRM inválido";

        domainValidation.VerificaCrm(crm);

        var exception = Assert.Throws<DomainException>(() =>
        {
            domainValidation.VerificaErros();
        });
        Assert.Contains(mensagem, exception.Mensagem);
        Assert.True(crm.Length >= 10);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void QuandoValidacaoCrmNaoPassarLancarExcecao(string crm)
    {
        DomainValidation domainValidation = new DomainValidation();
        string mensagem = "CRM inválido";

        domainValidation.VerificaCrm(crm);

        var exception = Assert.Throws<DomainException>(() =>
        {
            domainValidation.VerificaErros();
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void QuandoValidacaoIdNaoPassarLancarExcecao(int id)
    {
        DomainValidation domainValidation = new DomainValidation();
        string mensagem = "Id inválido";

        domainValidation.VerificaId(id);

        var exception = Assert.Throws<DomainException>(() =>
        {
            domainValidation.VerificaErros();
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(null)]
    public void QuandoValidacaoIdPossivelmenteNuloNaoPassarLancarExcecao(int? id)
    {
        DomainValidation domainValidation = new DomainValidation();
        string mensagem = "Id inválido";

        domainValidation.VerificaId(id);

        var exception = Assert.Throws<DomainException>(() =>
        {
            domainValidation.VerificaErros();
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("654654654")]
    public void QuandoValidacaoDeEnderecoNaoPassarLancarExcecao(string endereco)
    {
        DomainValidation domainValidation = new DomainValidation();
        string mensagem = "Endereço inválido";

        domainValidation.VerificaEndereco(endereco);

        var exception = Assert.Throws<DomainException>(() =>
        {
            domainValidation.VerificaErros();
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Fact]
    public void QuandoNaoHouverErrosListaDeErrosDeveEstarVazia()
    {
        DomainValidation domainValidation = new DomainValidation();

        domainValidation.VerificaErros();

        Assert.Equal(0, domainValidation.Erros.Count);
    }
}
