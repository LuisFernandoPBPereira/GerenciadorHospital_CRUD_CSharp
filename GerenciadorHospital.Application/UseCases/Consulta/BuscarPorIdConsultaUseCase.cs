using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Consulta;

public class BuscarPorIdConsultaUseCase
{
    private readonly IRegistroConsulta _consulta;

    public BuscarPorIdConsultaUseCase(IRegistroConsulta consulta)
    {
        _consulta = consulta;
    }

    public async Task<RegistroConsultaEntity> BuscarPorId(int id)
    {
        var consultaEntity = await _consulta.BuscarPorId(id);

        return consultaEntity;
    }
}
