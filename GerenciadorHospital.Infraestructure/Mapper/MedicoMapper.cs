using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Mapper;

public static class MedicoMapper
{
    public static MedicoModel ToModel(MedicoEntity medico)
    {
        return new MedicoModel
        {
            Id = medico.Id,
            Nome = medico.Nome,
            Cpf = medico.Cpf,
            DataNasc = medico.DataNasc,
            Endereco = medico.Endereco,
            Senha = medico.Senha,
            Crm = medico.Crm,
            Especializacao = medico.Especializacao
        };
    }

    public static MedicoEntity ToDomain(MedicoModel medico)
    {
        return new MedicoEntity
        {
            Id = medico.Id,
            Nome = medico.Nome,
            Cpf = medico.Cpf,
            DataNasc = medico.DataNasc,
            Endereco = medico.Endereco,
            Senha = medico.Senha,
            Crm = medico.Crm,
            Especializacao = medico.Especializacao
        };
    }
    
    public static IEnumerable<MedicoEntity> ToDomain(IEnumerable<MedicoModel> medicos)
    {
        var medicamentosEntity = new List<MedicoEntity>();

        foreach (var medico in medicos)
        {
            var medicoEntity = new MedicoEntity
            {
                Id = medico.Id,
                Nome = medico.Nome,
                Cpf = medico.Cpf,
                DataNasc = medico.DataNasc,
                Endereco = medico.Endereco,
                Senha = medico.Senha,
                Crm = medico.Crm,
                Especializacao = medico.Especializacao
            };

            medicamentosEntity.Add(medicoEntity);
        }

        return medicamentosEntity;
    }
}
