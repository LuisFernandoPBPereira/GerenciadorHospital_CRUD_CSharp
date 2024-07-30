using GerenciadorHospital.Application.DTOs.Responses;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Convenio;

public class ConvenioPorIdUseCase
{
    private readonly IConvenio _convenio;

    public ConvenioPorIdUseCase(IConvenio convenio)
    {
        _convenio = convenio;
    }

    public async Task<ConvenioResponseDto> Executar(int id)
    {
        var convenioEntity = await _convenio.BuscarPorId(id);
        var responseConvenio = new ConvenioResponseDto(convenioEntity);
        return responseConvenio;
    }
}
