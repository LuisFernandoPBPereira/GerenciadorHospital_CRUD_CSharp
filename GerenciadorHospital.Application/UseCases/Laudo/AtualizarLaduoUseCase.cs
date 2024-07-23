using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Laudo;

public class AtualizarLaduoUseCase
{
    private readonly ILaudo _laudo;

    public AtualizarLaduoUseCase(ILaudo laudo)
    {
        _laudo = laudo;
    }

    public async Task<LaudoEntity> Atualizar(LaudoRequestDto laudoDto)
    {
        var laudoEntity = new LaudoEntity(
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
