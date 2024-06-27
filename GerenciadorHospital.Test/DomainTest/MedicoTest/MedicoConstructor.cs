using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Exceptions;

namespace GerenciadorHospital.Test.DomainTest.MedicoTest;

public class MedicoConstructor
{
    [Theory]
    [InlineData(1, "medico", "00000000000", "caminhoDoc", "*Medico123", "rua tal", "1990-01-01", "000000-sp", "Dermatologista")]
    public void QuandoConstrutorValidoRetornarEntidade(
        int id,
        string nome,
        string cpf,
        string caminhoDoc,
        string senha,
        string endereco,
        DateTime dataNasc,
        string crm,
        string especializacao)
    {
        MedicoEntity medico = new MedicoEntity(id, nome, cpf, caminhoDoc, senha, endereco, dataNasc, crm, especializacao);

        Assert.NotNull(medico);
    }
    
    [Fact]
    public void QuandoConstrutorVazioRetornarEntidadeComStringsVazias()
    {
        MedicoEntity medico = new MedicoEntity();

        Assert.Equal(string.Empty, medico.Nome);
        Assert.Equal(string.Empty, medico.Cpf);
        Assert.Equal(string.Empty, medico.Senha);
        Assert.Equal(string.Empty, medico.Endereco);
        Assert.Equal(string.Empty, medico.Crm);
        Assert.Equal(string.Empty, medico.Especializacao);
    }

    [Theory]
    [InlineData(1, "", "", "", "", "", "1990-01-01", "", "")]
    public void QuandoConstrutorInvalidoLancarExcecao(
    int id,
    string nome,
    string cpf,
    string caminhoDoc,
    string senha,
    string endereco,
    DateTime dataNasc,
    string crm,
    string especializacao)
    {
        Assert.Throws<DomainException>(() => 
        { 
            MedicoEntity medico = new MedicoEntity(id, nome, cpf, caminhoDoc, senha, endereco, dataNasc, crm, especializacao);
        });
    }

    [Theory]
    [InlineData(0, "medico", "00000000000", "caminhoDoc", "*Medico123", "rua tal", "1990-01-01", "000000-sp", "Dermatologista")]
    public void QuandoIdInvalidoLancarExcecaoComMensagem(
    int id,
    string nome,
    string cpf,
    string caminhoDoc,
    string senha,
    string endereco,
    DateTime dataNasc,
    string crm,
    string especializacao)
    {
        string mensagem = "Id inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            MedicoEntity medico = new MedicoEntity(id, nome, cpf, caminhoDoc, senha, endereco, dataNasc, crm, especializacao);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "", "00000000000", "caminhoDoc", "*Medico123", "rua tal", "1990-01-01", "000000-sp", "Dermatologista")]
    [InlineData(1, null, "00000000000", "caminhoDoc", "*Medico123", "rua tal", "1990-01-01", "000000-sp", "Dermatologista")]
    public void QuandoNomeInvalidoLancarExcecaoComMensagem(
    int id,
    string nome,
    string cpf,
    string caminhoDoc,
    string senha,
    string endereco,
    DateTime dataNasc,
    string crm,
    string especializacao)
    {
        string mensagem = "Nome inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            MedicoEntity medico = new MedicoEntity(id, nome, cpf, caminhoDoc, senha, endereco, dataNasc, crm, especializacao);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "Medico", "", "caminhoDoc", "*Medico123", "rua tal", "1990-01-01", "000000-sp", "Dermatologista")]
    [InlineData(1, "Medico", null, "caminhoDoc", "*Medico123", "rua tal", "1990-01-01", "000000-sp", "Dermatologista")]
    public void QuandoCpfInvalidoLancarExcecao(
    int id,
    string nome,
    string cpf,
    string caminhoDoc,
    string senha,
    string endereco,
    DateTime dataNasc,
    string crm,
    string especializacao)
    {
        string mensagem = "CPF inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            MedicoEntity medico = new MedicoEntity(id, nome, cpf, caminhoDoc, senha, endereco, dataNasc, crm, especializacao);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "Medico", "00000000000", "", "*Medico123", "rua tal", "1990-01-01", "000000-sp", "Dermatologista")]
    [InlineData(1, "Medico", "00000000000", null, "*Medico123", "rua tal", "1990-01-01", "000000-sp", "Dermatologista")]
    public void QuandoCaminhoDoDocumentoInvalidoLancarExcecaoComMensagem(
    int id,
    string nome,
    string cpf,
    string caminhoDoc,
    string senha,
    string endereco,
    DateTime dataNasc,
    string crm,
    string especializacao)
    {
        string mensagem = "CaminhoDoc inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            MedicoEntity medico = new MedicoEntity(id, nome, cpf, caminhoDoc, senha, endereco, dataNasc, crm, especializacao);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "Medico", "00000000000", "caminhoDoc", "", "rua tal", "1990-01-01", "000000-sp", "Dermatologista")]
    [InlineData(1, "Medico", "00000000000", "caminhoDoc", null, "rua tal", "1990-01-01", "000000-sp", "Dermatologista")]
    [InlineData(1, "Medico", "00000000000", "caminhoDoc", "Medico123", "rua tal", "1990-01-01", "000000-sp", "Dermatologista")]
    public void QuandoSenhaInvalidaLancarExcecaoComMensagem(
    int id,
    string nome,
    string cpf,
    string caminhoDoc,
    string senha,
    string endereco,
    DateTime dataNasc,
    string crm,
    string especializacao)
    {
        string mensagem = "A senha deve conter no mínimo 6 caracteres, no mínimo 1 letra maiúscula, no mínimo 1 número e no mínimo 1 caractere especial";

        var exception = Assert.Throws<DomainException>(() =>
        {
            MedicoEntity medico = new MedicoEntity(id, nome, cpf, caminhoDoc, senha, endereco, dataNasc, crm, especializacao);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "medico", "00000000000", "caminhoDoc", "*Medico123", "", "1990-01-01", "000000-sp", "Dermatologista")]
    [InlineData(1, "medico", "00000000000", "caminhoDoc", "*Medico123", null, "1990-01-01", "000000-sp", "Dermatologista")]
    [InlineData(1, "medico", "00000000000", "caminhoDoc", "*Medico123", "25425453", "1990-01-01", "000000-sp", "Dermatologista")]
    public void QuandoEnderecoInvalidoLancarExcecaoComMensagem(
    int id,
    string nome,
    string cpf,
    string caminhoDoc,
    string senha,
    string endereco,
    DateTime dataNasc,
    string crm,
    string especializacao)
    {
        string mensagem = "Endereço inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            MedicoEntity medico = new MedicoEntity(id, nome, cpf, caminhoDoc, senha, endereco, dataNasc, crm, especializacao);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "medico", "00000000000", "caminhoDoc", "*Medico123", "rua tal", "2025-01-01", "000000-sp", "Dermatologista")]
    [InlineData(1, "medico", "00000000000", "caminhoDoc", "*Medico123", "rua tal", "1890-01-01", "000000-sp", "Dermatologista")]
    public void QuandoDataDeNascimentoInvalidaLancarExcecaoComMensagem(
    int id,
    string nome,
    string cpf,
    string caminhoDoc,
    string senha,
    string endereco,
    DateTime dataNasc,
    string crm,
    string especializacao)
    {
        string mensagem = "Data de nascimento inválida";

        var exception = Assert.Throws<DomainException>(() =>
        {
            MedicoEntity medico = new MedicoEntity(id, nome, cpf, caminhoDoc, senha, endereco, dataNasc, crm, especializacao);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "medico", "00000000000", "caminhoDoc", "*Medico123", "rua tal", "2000-01-01", "", "Dermatologista")]
    [InlineData(1, "medico", "00000000000", "caminhoDoc", "*Medico123", "rua tal", "1990-01-01", null, "Dermatologista")]
    [InlineData(1, "medico", "00000000000", "caminhoDoc", "*Medico123", "rua tal", "1990-01-01", "000000000-sp", "Dermatologista")]
    public void QuandoCrmInvalidoLancarExcecaoComMensagem(
    int id,
    string nome,
    string cpf,
    string caminhoDoc,
    string senha,
    string endereco,
    DateTime dataNasc,
    string crm,
    string especializacao)
    {
        string mensagem = "CRM inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            MedicoEntity medico = new MedicoEntity(id, nome, cpf, caminhoDoc, senha, endereco, dataNasc, crm, especializacao);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "medico", "00000000000", "caminhoDoc", "*Medico123", "rua tal", "2000-01-01", "000000-sp", "")]
    [InlineData(1, "medico", "00000000000", "caminhoDoc", "*Medico123", "rua tal", "1990-01-01", "000000-sp", null)]
    [InlineData(1, "medico", "00000000000", "caminhoDoc", "*Medico123", "rua tal", "1990-01-01", "000000-sp", "Dermatologista354354")]
    public void QuandoEspecializacaoInvalidaLancarExcecaoComMensagem(
    int id,
    string nome,
    string cpf,
    string caminhoDoc,
    string senha,
    string endereco,
    DateTime dataNasc,
    string crm,
    string especializacao)
    {
        string mensagem = "Especializacao inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            MedicoEntity medico = new MedicoEntity(id, nome, cpf, caminhoDoc, senha, endereco, dataNasc, crm, especializacao);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }
}
