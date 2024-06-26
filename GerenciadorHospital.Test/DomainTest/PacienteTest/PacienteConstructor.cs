using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Exceptions;

namespace GerenciadorHospital.Test.DomainTest.PacienteTest;

public class PacienteConstructor
{
    [Theory]
    [InlineData(1, "paciente", "00000000000", "*Paciente123", "rua tal", "1990-01-01", false, null, "blabla", null)]
    public void QuandoConstrutorValidoRetornarEntidade(
        int id,
        string nome,
        string cpf,
        string senha,
        string endereco,
        DateTime dataNasc,
        bool temConvenio,
        string? imgCarteiraDoConvenio,
        string imgDocumento,
        int? convenioId)
    {
        PacienteEntity paciente = new PacienteEntity(
            id, nome, cpf, senha, endereco, dataNasc, temConvenio, imgCarteiraDoConvenio, imgDocumento, convenioId);

        Assert.NotNull(paciente);
    }

    [Theory]
    [InlineData(1, "", "", "", "", "1990-01-01", false, null, "blabla", null)]
    public void QuandoConstrutorInvalidoLancarExcecao(
    int id,
    string nome,
    string cpf,
    string senha,
    string endereco,
    DateTime dataNasc,
    bool temConvenio,
    string? imgCarteiraDoConvenio,
    string imgDocumento,
    int? convenioId)
    {
        
        Assert.Throws<DomainException>(() => 
        {
            PacienteEntity paciente = new PacienteEntity(
                id, nome, cpf, senha, endereco, dataNasc, temConvenio, imgCarteiraDoConvenio, imgDocumento, convenioId);

        });
    }

    [Theory]
    [InlineData(0, "paciente", "00000000000", "*Paciente123", "rua tal", "1990-01-01", false, null, "blabla", 1)]
    [InlineData(1, "paciente", "00000000000", "*Paciente123", "rua tal", "1990-01-01", false, null, "blabla", 0)]
    public void QuandoIdInvalidoLancarExcecaoComMensagem(
    int id,
    string nome,
    string cpf,
    string senha,
    string endereco,
    DateTime dataNasc,
    bool temConvenio,
    string? imgCarteiraDoConvenio,
    string imgDocumento,
    int? convenioId)
    {
        string mensagem = "Id inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            PacienteEntity paciente = new PacienteEntity(
                id, nome, cpf, senha, endereco, dataNasc, temConvenio, imgCarteiraDoConvenio, imgDocumento, convenioId);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, null, "00000000000", "*Paciente123", "rua tal", "1990-01-01", false, null, "blabla", 1)]
    [InlineData(1, "", "00000000000", "*Paciente123", "rua tal", "1990-01-01", false, null, "blabla", 1)]
    [InlineData(1, "paciente123", "00000000000", "*Paciente123", "rua tal", "1990-01-01", false, null, "blabla", 1)]
    public void QuandoNomeInvalidoLancarExcecaoComMensagem(
    int id,
    string nome,
    string cpf,
    string senha,
    string endereco,
    DateTime dataNasc,
    bool temConvenio,
    string? imgCarteiraDoConvenio,
    string imgDocumento,
    int? convenioId)
    {
        string mensagem = "Nome inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            PacienteEntity paciente = new PacienteEntity(
                id, nome, cpf, senha, endereco, dataNasc, temConvenio, imgCarteiraDoConvenio, imgDocumento, convenioId);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "Paciente", null, "*Paciente123", "rua tal", "1990-01-01", false, null, "blabla", 1)]
    [InlineData(1, "Paciente", "", "*Paciente123", "rua tal", "1990-01-01", false, null, "blabla", 1)]
    public void QuandoCpfInvalidoLancarExcecao(
    int id,
    string nome,
    string cpf,
    string senha,
    string endereco,
    DateTime dataNasc,
    bool temConvenio,
    string? imgCarteiraDoConvenio,
    string imgDocumento,
    int? convenioId)
    {
        string mensagem = "CPF inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            PacienteEntity paciente = new PacienteEntity(
                id, nome, cpf, senha, endereco, dataNasc, temConvenio, imgCarteiraDoConvenio, imgDocumento, convenioId);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "Paciente", "00000000000", null, "rua tal", "1990-01-01", false, null, "blabla", 1)]
    [InlineData(1, "Paciente", "00000000000", "Paciente123", "rua tal", "1990-01-01", false, null, "blabla", 1)]
    [InlineData(1, "Paciente", "00000000000", "", "rua tal", "1990-01-01", false, null, "blabla", 1)]
    public void QuandoSenhaInvalidaLancarExcecaoComMensagem(
    int id,
    string nome,
    string cpf,
    string senha,
    string endereco,
    DateTime dataNasc,
    bool temConvenio,
    string? imgCarteiraDoConvenio,
    string imgDocumento,
    int? convenioId)
    {
        string mensagem = "A senha deve conter no mínimo 6 caracteres, no mínimo 1 letra maiúscula, no mínimo 1 número e no mínimo 1 caractere especial";
        
        var exception = Assert.Throws<DomainException>(() =>
        {
            PacienteEntity paciente = new PacienteEntity(
                id, nome, cpf, senha, endereco, dataNasc, temConvenio, imgCarteiraDoConvenio, imgDocumento, convenioId);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "Paciente", "00000000000", "*Paciente123", "", "1990-01-01", false, null, "blabla", 1)]
    [InlineData(1, "Paciente", "00000000000", "*Paciente123", null, "1990-01-01", false, null, "blabla", 1)]
    [InlineData(1, "Paciente", "00000000000", "*Paciente123", "534354", "1990-01-01", false, null, "blabla", 1)]
    public void QuandoEnderecoInvalidoLancarExcecaoComMensagem(
    int id,
    string nome,
    string cpf,
    string senha,
    string endereco,
    DateTime dataNasc,
    bool temConvenio,
    string? imgCarteiraDoConvenio,
    string imgDocumento,
    int? convenioId)
    {
        string mensagem = "Endereço inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            PacienteEntity paciente = new PacienteEntity(
                id, nome, cpf, senha, endereco, dataNasc, temConvenio, imgCarteiraDoConvenio, imgDocumento, convenioId);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "Paciente", "00000000000", "*Paciente123", "rua tal", "1899-01-01", false, null, "blabla", 1)]
    [InlineData(1, "Paciente", "00000000000", "*Paciente123", "rua tal", "2025-01-01", false, null, "blabla", 1)]
    public void QuandoDataDeNascimentoInvalidaLancarExcecaoComMensagem(
    int id,
    string nome,
    string cpf,
    string senha,
    string endereco,
    DateTime dataNasc,
    bool temConvenio,
    string? imgCarteiraDoConvenio,
    string imgDocumento,
    int? convenioId)
    {
        string mensagem = "Data de nascimento inválida";

        var exception = Assert.Throws<DomainException>(() =>
        {
            PacienteEntity paciente = new PacienteEntity(
                id, nome, cpf, senha, endereco, dataNasc, temConvenio, imgCarteiraDoConvenio, imgDocumento, convenioId);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "Paciente", "00000000000", "*Paciente123", "rua tal", "1899-01-01", false, null, null, 1)]
    [InlineData(1, "Paciente", "00000000000", "*Paciente123", "rua tal", "2025-01-01", false, null, "", 1)]
    public void QuandoImagemDoDocumentoInvalidaLancarExcecaoComMensagem(
    int id,
    string nome,
    string cpf,
    string senha,
    string endereco,
    DateTime dataNasc,
    bool temConvenio,
    string? imgCarteiraDoConvenio,
    string imgDocumento,
    int? convenioId)
    {
        string mensagem = "ImgDocumento inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            PacienteEntity paciente = new PacienteEntity(
                id, nome, cpf, senha, endereco, dataNasc, temConvenio, imgCarteiraDoConvenio, imgDocumento, convenioId);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }
}

