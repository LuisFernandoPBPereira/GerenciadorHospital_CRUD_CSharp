using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Mapper;

public static class MedicoMapper
{
    public static MedicoModel ToModel(MedicoEntity medico)
    {
        return new MedicoModel
        {
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
            Nome = medico.Nome,
            Cpf = medico.Cpf,
            DataNasc = medico.DataNasc,
            Endereco = medico.Endereco,
            Senha = medico.Senha,
            Crm = medico.Crm,
            Especializacao = medico.Especializacao
        };
    }
}
