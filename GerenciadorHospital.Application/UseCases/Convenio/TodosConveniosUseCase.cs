using GerenciadorHospital.Application.DTOs.Responses;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Convenio;

public class TodosConveniosUseCase
{
    private readonly IConvenio _convenio;

    public TodosConveniosUseCase(IConvenio convenio)
    {
        _convenio = convenio;
    }

    public async Task<IEnumerable<ConvenioResponseDto>> Executar()
    {
        var convenios = await _convenio.BuscarTodos();
        var conveniosDto = new List<ConvenioResponseDto>();
        
        foreach (var convenio in convenios)
        {
            var responseConvenio = new ConvenioResponseDto(convenio);
            conveniosDto.Add(responseConvenio);
        }

        return conveniosDto;
    }
}
