using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Laudo;

public class BuscarPorIdLaudoUseCase
{
    private readonly ILaudo _laudo;

    public BuscarPorIdLaudoUseCase(ILaudo laudo)
    {
        _laudo = laudo;
    }

    public async Task<LaudoEntity> BuscarPorId(int id)
    {
        var laudoEntity = await _laudo.BuscarPorId(id);
        
        return laudoEntity;
    }
}
