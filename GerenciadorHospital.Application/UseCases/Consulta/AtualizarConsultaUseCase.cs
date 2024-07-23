using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Consulta;

public class AtualizarConsultaUseCase
{
    private readonly IRegistroConsulta _consulta;

    public AtualizarConsultaUseCase(IRegistroConsulta consulta)
    {
        _consulta = consulta;
    }

    public async Task<RegistroConsultaEntity> Atualizar(ConsultaRequestDto consultaDto)
    {
        var consultaEntity = new RegistroConsultaEntity(
            consultaDto.DataConsulta,
            consultaDto.Valor,
            consultaDto.DataRetorno,
            consultaDto.Retorno,
            consultaDto.PacienteId,
            consultaDto.MedicoId,
            consultaDto.ExameId);

        var consultaAtualizada = await _consulta.Atualizar(consultaEntity);
    
        return consultaAtualizada;
    }
}
