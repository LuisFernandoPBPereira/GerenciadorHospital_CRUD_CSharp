using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Laudo;

public class AtualizarLaudoUseCase
{
    private readonly ILaudo _laudo;

    public AtualizarLaudoUseCase(ILaudo laudo)
    {
        _laudo = laudo;
    }

    public async Task<LaudoEntity> Executar(int id, LaudoRequestDto laudoDto)
    {
        var laudoEntity = new LaudoEntity(
            id,
            laudoDto.Descricao,
            laudoDto.DataCriacao,
            laudoDto.PacienteId,
            laudoDto.MedicoId,
            laudoDto.MedicamentoId,
            laudoDto.RegistroConsultaModelId);
    
        var laudoAtualizado = await _laudo.Atualizar(laudoEntity);

        return laudoAtualizado;
    }
}
