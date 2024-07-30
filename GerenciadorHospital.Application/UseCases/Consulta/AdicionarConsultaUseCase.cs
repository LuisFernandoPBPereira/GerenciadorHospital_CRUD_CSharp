using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Consulta;

public class AdicionarConsultaUseCase
{
    private readonly IRegistroConsulta _consulta;

    public AdicionarConsultaUseCase(IRegistroConsulta consulta)
    {
        _consulta = consulta;
    }

    public async Task<RegistroConsultaEntity> Adicionar(ConsultaRequestDto consultaDto)
    {
        var consultaEntity = new RegistroConsultaEntity(
            consultaDto.DataConsulta, 
            consultaDto.Valor, 
            consultaDto.DataRetorno,
            consultaDto.EstadoConsulta,
            consultaDto.Retorno, 
            consultaDto.PacienteId, 
            consultaDto.MedicoId, 
            consultaDto.ExameId);
        
        var consultaAdicionada = await _consulta.Adicionar(consultaEntity);

        return consultaAdicionada;
    }
}
