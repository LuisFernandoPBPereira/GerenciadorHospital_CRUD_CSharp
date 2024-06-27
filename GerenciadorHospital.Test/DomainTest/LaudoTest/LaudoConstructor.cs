using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Exceptions;

namespace GerenciadorHospital.Test.DomainTest.LaudoTest;

public class LaudoConstructor
{
    [Theory]
    [InlineData(1, "descrição", "2024-06-28", "caminho da imagem", 1, 1, 1, 1)]
    public void QuandoConstrutorValidoRetornarEntidade(
    int id,
    string descricao,
    DateTime dataCriacao,
    string caminhoImagemLaudo,
    int pacienteId,
    int medicoId,
    int medicamentoId,
    int registroConsultaModelId)
    {
        LaudoEntity laudo = new LaudoEntity(
            id,
            descricao,
            dataCriacao,
            caminhoImagemLaudo,
            pacienteId,
            medicoId,
            medicamentoId,
            registroConsultaModelId);

        Assert.NotNull(laudo);
    }
    
    [Fact]
    public void QuandoConstrutorVazioRetornarEntidadeComStringsVazias()
    {
        LaudoEntity laudo = new LaudoEntity();

        Assert.Equal(string.Empty, laudo.Descricao);
    }
    
    [Theory]
    [InlineData(1, "", "2024-06-27", "", 1, 1, 1, 1)]
    public void QuandoConstrutorInvalidoLancarExcecao(
    int id,
    string descricao,
    DateTime dataCriacao,
    string caminhoImagemLaudo,
    int pacienteId,
    int medicoId,
    int medicamentoId,
    int registroConsultaModelId)
    {
        Assert.Throws<DomainException>(() => 
        { 
            LaudoEntity laudo = new LaudoEntity(
                id,
                descricao,
                dataCriacao,
                caminhoImagemLaudo,
                pacienteId,
                medicoId,
                medicamentoId,
                registroConsultaModelId);            
        });
    }

    [Theory]
    [InlineData(0, "descrição", "2024-06-27", "caminho da imagem", 1, 1, 1, 1)]
    [InlineData(1, "descrição", "2024-06-27", "caminho da imagem", 0, 1, 1, 1)]
    [InlineData(1, "descrição", "2024-06-27", "caminho da imagem", 1, 0, 1, 1)]
    [InlineData(1, "descrição", "2024-06-27", "caminho da imagem", 1, 1, 0, 1)]
    [InlineData(1, "descrição", "2024-06-27", "caminho da imagem", 1, 1, 1, 0)]
    public void QuandoIdInvalidoLancarExcecaoComMensagem(
    int id,
    string descricao,
    DateTime dataCriacao,
    string caminhoImagemLaudo,
    int pacienteId,
    int medicoId,
    int medicamentoId,
    int registroConsultaModelId)
    {
        string mensagem = "Id inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            LaudoEntity laudo = new LaudoEntity(
                id,
                descricao,
                dataCriacao,
                caminhoImagemLaudo,
                pacienteId,
                medicoId,
                medicamentoId,
                registroConsultaModelId);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "", "2024-06-27", "caminho da imagem", 1, 1, 1, 1)]
    [InlineData(1, null, "2024-06-27", "caminho da imagem", 1, 1, 1, 1)]
    [InlineData(1, "descrição121322134", "2024-06-27", "caminho da imagem", 1, 1, 1, 1)]
    public void QuandoDescricaoInvalidaLancarExcecaoComMensagem(
    int id,
    string descricao,
    DateTime dataCriacao,
    string caminhoImagemLaudo,
    int pacienteId,
    int medicoId,
    int medicamentoId,
    int registroConsultaModelId)
    {
        string mensagem = "Descricao inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            LaudoEntity laudo = new LaudoEntity(
                id,
                descricao,
                dataCriacao,
                caminhoImagemLaudo,
                pacienteId,
                medicoId,
                medicamentoId,
                registroConsultaModelId);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "descrição", "2024-01-27", "caminho da imagem", 1, 1, 1, 1)]
    public void QuandoDataDeCriacaoInvalidaLancarExcecaoComMensagem(
    int id,
    string descricao,
    DateTime dataCriacao,
    string caminhoImagemLaudo,
    int pacienteId,
    int medicoId,
    int medicamentoId,
    int registroConsultaModelId)
    {
        string mensagem = "DataCriacao inválida";

        var exception = Assert.Throws<DomainException>(() =>
        {
            LaudoEntity laudo = new LaudoEntity(
                id,
                descricao,
                dataCriacao,
                caminhoImagemLaudo,
                pacienteId,
                medicoId,
                medicamentoId,
                registroConsultaModelId);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "descrição", "2024-06-27", "", 1, 1, 1, 1)]
    [InlineData(1, "descrição", "2024-06-27", null, 1, 1, 1, 1)]
    public void QuandoCaminhoDaImagemLaudoInvalidaLancarExcecaoComMensagem(
    int id,
    string descricao,
    DateTime dataCriacao,
    string caminhoImagemLaudo,
    int pacienteId,
    int medicoId,
    int medicamentoId,
    int registroConsultaModelId)
    {
        string mensagem = "CaminhoImagemLaudo inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            LaudoEntity laudo = new LaudoEntity(
                id,
                descricao,
                dataCriacao,
                caminhoImagemLaudo,
                pacienteId,
                medicoId,
                medicamentoId,
                registroConsultaModelId);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }
}
