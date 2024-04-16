using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Medico
{
    public class MedicoService : IMedicoService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMedicoRepositorio _medicoRepositorio;

        public MedicoService(IAuthenticationService authenticationService,
                             IMedicoRepositorio medicoRepositorio)
        {
            _authenticationService = authenticationService;
            _medicoRepositorio = medicoRepositorio;
        }
        public async Task<MedicoModel> Adicionar(MedicoModel medicoModel)
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

        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _medicoRepositorio.Apagar(id);
            return apagado;
        }

        public async Task<MedicoModel> Atualizar(MedicoModel medicoModel, int id)
        {
            medicoModel.Id = id;
            MedicoModel medico = await _medicoRepositorio.Atualizar(medicoModel, id);
            return medico;
        }

        public async Task<MedicoModel> BuscarPorId(int id)
        {
            MedicoModel medicos = await _medicoRepositorio.BuscarPorId(id);
            return medicos;
        }

        public async Task<List<MedicoModel>> BuscarTodosMedicos()
        {
            List<MedicoModel> medicos = await _medicoRepositorio.BuscarTodosMedicos();
            return medicos;
        }
    }
}
