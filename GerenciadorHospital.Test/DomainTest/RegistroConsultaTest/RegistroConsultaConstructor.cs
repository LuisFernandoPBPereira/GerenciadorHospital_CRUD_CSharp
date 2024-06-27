using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Exceptions;

namespace GerenciadorHospital.Test.DomainTest.RegistroConsultaTest;

public class RegistroConsultaConstructor
{
    [Fact]
    public void QuandoConstrutorValidoRetornarEntidade()
    {
        int id = 1;
        DateTime dataConsulta = DateTime.Now.AddMinutes(10);
        decimal valor = 100;
        DateTime dataRetorno = DateTime.Now.AddMinutes(10);
        bool retorno = false;
        int pacienteId = 1;
        int medicoId = 1;
        int exameId = 1;

        RegistroConsultaEntity consulta = new RegistroConsultaEntity(id, dataConsulta, valor, dataRetorno, retorno, pacienteId, medicoId, exameId);

        Assert.NotNull(consulta);
    }

    [Fact]
    public void QuandoConstrutorInvalidoLancarExcecao()
    {
        int id = 1;
        DateTime dataConsulta = DateTime.Now.AddMinutes(10);
        decimal valor = -100;
        DateTime dataRetorno = DateTime.Now;
        bool retorno = false;
        int pacienteId = 1;
        int medicoId = 1;
        int exameId = 1;

        Assert.Throws<DomainException>(() => 
        {
            RegistroConsultaEntity consulta = new RegistroConsultaEntity(id, dataConsulta, valor, dataRetorno, retorno, pacienteId, medicoId, exameId);
        });
    }

    [Theory]
    [InlineData(0, "2024-06-27", 100, "2024-06-27", false, 1, 1, 1)]
    [InlineData(1, "2024-06-27", 100, "2024-06-27", false, 0, 1, 1)]
    [InlineData(1, "2024-06-27", 100, "2024-06-27", false, 1, 0, 1)]
    [InlineData(1, "2024-06-27", 100, "2024-06-27", false, 1, 1, 0)]
    public void QuandoIdInvalidoLancarExcecaoComMensagem(
        int id,
        DateTime dataConsulta,
        decimal valor,
        DateTime dataRetorno,
        bool retorno,
        int pacienteId,
        int medicoId,
        int exameId)
    {
        string mensagem = "Id inválido";

        var exception = Assert.Throws<DomainException>(() => 
        {  
            RegistroConsultaEntity consulta = new RegistroConsultaEntity(id, dataConsulta, valor, dataRetorno, retorno, pacienteId, medicoId, exameId);
        });

        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "2023-06-27", 100, "2024-06-27", false, 1, 1, 1)]
    public void QuandoDataConsultaInvalidaLancarExcecaoComMensagem(
        int id,
        DateTime dataConsulta,
        decimal valor,
        DateTime dataRetorno,
        bool retorno,
        int pacienteId,
        int medicoId,
        int exameId)
    {
        string mensagem = "DataConsulta inválida";

        var exception = Assert.Throws<DomainException>(() =>
        {
            RegistroConsultaEntity consulta = new RegistroConsultaEntity(id, dataConsulta, valor, dataRetorno, retorno, pacienteId, medicoId, exameId);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }
    
    [Theory]
    [InlineData(1, "2024-06-27", 100, "2023-06-27", false, 1, 1, 1)]
    public void QuandoDataRetornoInvalidaLancarExcecaoComMensagem(
        int id,
        DateTime dataConsulta,
        decimal valor,
        DateTime dataRetorno,
        bool retorno,
        int pacienteId,
        int medicoId,
        int exameId)
    {
        string mensagem = "DataRetorno inválida";

        var exception = Assert.Throws<DomainException>(() =>
        {
            RegistroConsultaEntity consulta = new RegistroConsultaEntity(id, dataConsulta, valor, dataRetorno, retorno, pacienteId, medicoId, exameId);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "2024-06-27", -100, "2024-06-27", false, 1, 1, 1)]
    public void QuandoValorInvalidoLancarExcecaoComMensagem(
        int id,
        DateTime dataConsulta,
        decimal valor,
        DateTime dataRetorno,
        bool retorno,
        int pacienteId,
        int medicoId,
        int exameId)
    {
        string mensagem = "Preço não pode ser negativo";

        var exception = Assert.Throws<DomainException>(() =>
        {
            RegistroConsultaEntity consulta = new RegistroConsultaEntity(id, dataConsulta, valor, dataRetorno, retorno, pacienteId, medicoId, exameId);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }
}
