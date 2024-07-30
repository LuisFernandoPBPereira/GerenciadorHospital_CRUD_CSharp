using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Convenio;

public class AtualizarConvenioUseCase
{
    private readonly IConvenio _convenio;
    private readonly BuscarPorIdConvenioUseCase _buscarPorIdConvenioUseCase;

    public AtualizarConvenioUseCase(IConvenio convenio, BuscarPorIdConvenioUseCase buscarPorIdConvenioUseCase)
    {
        _convenio = convenio;
        _buscarPorIdConvenioUseCase = buscarPorIdConvenioUseCase;
    }

    public async Task<ConvenioEntity> Atualizar(int id, ConvenioRequestDto convenioDto)
    {
        var convenio = new ConvenioEntity(id, convenioDto.Nome, convenioDto.Preco);
        
        var convenioAtualizado = await _convenio.Atualizar(convenio);

        return convenioAtualizado;
    }
}
