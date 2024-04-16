using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Medico
{
    public class MedicoService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMedicoRepositorio _medicoRepositorio;

        public MedicoService(IAuthenticationService authenticationService,
                             IMedicoRepositorio medicoRepositorio)
        {
            _authenticationService = authenticationService;
            _medicoRepositorio = medicoRepositorio;
        }
        public async Task<MedicoModel> AdicionarMedico(MedicoModel medicoModel)
        {
            MedicoModel medico = await _medicoRepositorio.Adicionar(medicoModel);

            CadastroRequestDto novoMedico = new CadastroRequestDto();

            novoMedico.Nome = medico.Nome;
            novoMedico.UserName = medico.Crm;
            novoMedico.Cpf = medico.Cpf;
            novoMedico.Senha = medico.Senha;
            novoMedico.DataNasc = medico.DataNasc;
            novoMedico.Endereco = medico.Endereco;
            novoMedico.Role = Role.Medico;

            await _authenticationService.Register(novoMedico);

            return medico;
        }
    }
}
