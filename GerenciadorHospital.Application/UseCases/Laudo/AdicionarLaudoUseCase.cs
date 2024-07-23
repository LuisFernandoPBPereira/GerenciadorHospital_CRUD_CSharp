using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Laudo;

public class AdicionarLaudoUseCase
{
    private readonly ILaudo _laudo;

    public AdicionarLaudoUseCase(ILaudo laudo)
    {
        _laudo = laudo;
    }

    public async Task<LaudoEntity> Adicionar(LaudoRequestDto laudoDto)
    {
        var laudoEntity = new LaudoEntity(
            laudoDto.Descricao, 
            laudoDto.DataCriacao, 
            laudoDto.PacienteId, 
            laudoDto.MedicoId, 
            laudoDto.MedicamentoId,
            laudoDto.RegistroConsultaModelId );
        
        var laudoAdicionado = await _laudo.Adicionar(laudoEntity);

        return laudoAdicionado;
    }
}
