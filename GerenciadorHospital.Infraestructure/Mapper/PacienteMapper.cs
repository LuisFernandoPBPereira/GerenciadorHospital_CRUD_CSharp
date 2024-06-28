using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Infraestructure.Mapper;

public static class PacienteMapper
{
    public static PacienteModel ToModel(PacienteEntity paciente)
    {
        return new PacienteModel
        {
            Id = paciente.Id,
            Nome = paciente.Nome,
            Cpf = paciente.Cpf,
            DataNasc = paciente.DataNasc,
            ImgDocumento = paciente.ImgDocumento,
            ImgCarteiraDoConvenio = paciente.ImgCarteiraDoConvenio,
            Senha = paciente.Senha,
            Endereco = paciente.Endereco,
            TemConvenio = paciente.TemConvenio,
            ConvenioId = paciente.ConvenioId
        };
    }

    public static PacienteEntity ToDomain(PacienteModel paciente)
    {
        return new PacienteEntity
        {
            Id = paciente.Id,
            Nome = paciente.Nome,
            Cpf = paciente.Cpf,
            DataNasc = paciente.DataNasc,
            ImgDocumento = paciente.ImgDocumento,
            ImgCarteiraDoConvenio = paciente.ImgCarteiraDoConvenio,
            Senha = paciente.Senha,
            Endereco = paciente.Endereco,
            TemConvenio = paciente.TemConvenio,
            ConvenioId = paciente.ConvenioId
        };
    }
}
