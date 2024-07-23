using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Consulta;

public class RemoverConsultaUseCase
{
    private readonly IRegistroConsulta _consulta;

    public RemoverConsultaUseCase(IRegistroConsulta consulta)
    {
        _consulta = consulta;
    }

    public async Task<bool> Remover(int id)
    {
        var consultaApagada = await _consulta.Apagar(id);

        return consultaApagada;
    }
}
