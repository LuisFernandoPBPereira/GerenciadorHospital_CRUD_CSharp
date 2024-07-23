using GerenciadorHospital.Application.DTOs.Requests;
using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Application.UseCases.Medico;

public class AdicionarMedicoUseCase
{
    private readonly IMedico _medico;

    public AdicionarMedicoUseCase(IMedico medico)
    {
        _medico = medico;
    }

    public async Task<MedicoEntity> Adicionar(MedicoRequestDto medicoDto)
    {
        var medicoEntity = new MedicoEntity(
            medicoDto.Nome, 
            medicoDto.Cpf,
            medicoDto.Senha,
            medicoDto.Endereco,
            medicoDto.DataNasc,
            medicoDto.Crm,
            medicoDto.Especializacao);

        var medicoAdicionado = await _medico.Adicionar(medicoEntity);

        return medicoAdicionado;
    }
}
