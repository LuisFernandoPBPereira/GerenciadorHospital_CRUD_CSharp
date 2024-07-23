using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Convenio;

public class AtualizarConvenioUseCase
{
    private readonly IConvenio _convenio;

    public AtualizarConvenioUseCase(IConvenio convenio)
    {
        _convenio = convenio;
    }

    public async Task<ConvenioEntity> Atualizar(ConvenioRequestDto convenioDto)
    {
        var convenioEntity = new ConvenioEntity(convenioDto.Nome, convenioDto.Preco);
        var convenioAtualizado = await _convenio.Atualizar(convenioEntity);

        return convenioAtualizado;
    }
}
