using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Convenio;

public class AdicionarConvenioUseCase
{
    private readonly IConvenio _convenio;

    public AdicionarConvenioUseCase(IConvenio convenio)
    {
        _convenio = convenio;
    }

    public async Task<ConvenioEntity> Executar(ConvenioRequestDto convenioDto)
    {
        var convenioEntity = new ConvenioEntity(convenioDto.Nome, convenioDto.Preco);
        var convenioAdicionado = await _convenio.Adicionar(convenioEntity);
    
        return convenioAdicionado;
    }
}
