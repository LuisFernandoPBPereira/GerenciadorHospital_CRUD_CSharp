using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Exceptions;

namespace GerenciadorHospital.Test.DomainTest.MedicamentoTest;

public class MedicamenteConstructor
{
    [Theory]
    [InlineData(1, "dipirona", "dipirona", "2024-06-27", "2025-04-04")]
    public void QuandoConstrutorValidoRetornarEntidade(int id, string nome, string composicao, DateTime dataFabricacao, DateTime dataValidade)
    {
        MedicamentoEntity medicamento = new MedicamentoEntity(id, nome, composicao, dataFabricacao, dataValidade);

        Assert.NotNull(medicamento);
    }
    
    [Theory]
    [InlineData(1, "", "", "2024-04-04", "2025-04-04")]
    public void QuandoConstrutorInvalidoLancarExcecao(int id, string nome, string composicao, DateTime dataFabricacao, DateTime dataValidade)
    {
        Assert.Throws<DomainException>(() => { MedicamentoEntity medicamento = new MedicamentoEntity(id, nome, composicao, dataFabricacao, dataValidade); });
    }

    [Theory]
    [InlineData(0, "dipirona", "dipirona", "2024-04-04", "2025-04-04")]
    public void QuandoIdInvalidoLancarExcecaoComMensagem(int id, string nome, string composicao, DateTime dataFabricacao, DateTime dataValidade)
    {
        string mensagem = "Id inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            MedicamentoEntity medicamento = new MedicamentoEntity(id, nome, composicao, dataFabricacao, dataValidade);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "", "dipirona", "2024-04-04", "2025-04-04")]
    [InlineData(1, null, "dipirona", "2024-04-04", "2025-04-04")]
    [InlineData(1, "dipirona45454", "dipirona", "2024-04-04", "2025-04-04")]
    public void QuandoNomeInvalidoLancarExcecaoComMensagem(int id, string nome, string composicao, DateTime dataFabricacao, DateTime dataValidade)
    {
        string mensagem = "Nome inválido";

        var exception = Assert.Throws<DomainException>(() =>
        {
            MedicamentoEntity medicamento = new MedicamentoEntity(id, nome, composicao, dataFabricacao, dataValidade);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }

    [Theory]
    [InlineData(1, "dipirona", "dipirona", "2024-04-04", "2025-10-10")]
    public void QuandoDataDeFabricacaoInvalidaLancarExcecaoComMensagem(int id, string nome, string composicao, DateTime dataFabricacao, DateTime dataValidade)
    {
        string mensagem = "DataFabricacao inválida";

        var exception = Assert.Throws<DomainException>(() =>
        {
            MedicamentoEntity medicamento = new MedicamentoEntity(id, nome, composicao, dataFabricacao, dataValidade);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }
    
    [Theory]
    [InlineData(1, "dipirona", "dipirona", "2024-10-10", "2023-10-10")]
    public void QuandoDataDeValidadeInvalidaLancarExcecaoComMensagem(int id, string nome, string composicao, DateTime dataFabricacao, DateTime dataValidade)
    {
        string mensagem = "DataValidade inválida";

        var exception = Assert.Throws<DomainException>(() =>
        {
            MedicamentoEntity medicamento = new MedicamentoEntity(id, nome, composicao, dataFabricacao, dataValidade);
        });
        Assert.Contains(mensagem, exception.Mensagem);
    }
}
