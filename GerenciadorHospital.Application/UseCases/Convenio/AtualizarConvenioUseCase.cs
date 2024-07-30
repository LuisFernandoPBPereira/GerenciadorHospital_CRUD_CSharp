using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Convenio;

public class AtualizarConvenioUseCase
{
    private readonly IConvenio _convenio;
    private readonly ConvenioPorIdUseCase _buscarPorIdConvenioUseCase;

    public AtualizarConvenioUseCase(IConvenio convenio, ConvenioPorIdUseCase buscarPorIdConvenioUseCase)
    {
        _convenio = convenio;
        _buscarPorIdConvenioUseCase = buscarPorIdConvenioUseCase;
    }

    public async Task<ConvenioEntity> Executar(int id, ConvenioRequestDto convenioDto)
    {
        var convenio = new ConvenioEntity(id, convenioDto.Nome, convenioDto.Preco);
        
        var convenioAtualizado = await _convenio.Atualizar(convenio);

        return convenioAtualizado;
    }
}
