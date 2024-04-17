using GerenciadorHospital.Controllers;
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
        private readonly ILogger<MedicoController> _logger;

        public MedicoService(IAuthenticationService authenticationService,
                             IMedicoRepositorio medicoRepositorio,
                             ILogger<MedicoController> logger)
        {
            _authenticationService = authenticationService;
            _medicoRepositorio = medicoRepositorio;
            _logger = logger;
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

            var medicoCadastrado = await _authenticationService.Register(novoMedico);

            if (medico is not null && medicoCadastrado is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medico)}: Cadastro do médico foi realizado.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Medico)}: Cadastro do médico não foi realizado.");

            return medico;
        }

        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _medicoRepositorio.Apagar(id);

            if (apagado)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medico)}: Remoção do médico foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Medico)}: Remoção do médico não foi realizada.");

            return apagado;
        }

        public async Task<MedicoModel> Atualizar(MedicoModel medicoModel, int id)
        {
            medicoModel.Id = id;
            MedicoModel medico = await _medicoRepositorio.Atualizar(medicoModel, id);

            if (medico is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medico)}: Atualização do médico foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Medico)}: Atualização do médico não foi realizada.");

            return medico;
        }

        public async Task<MedicoModel> BuscarPorId(int id)
        {
            MedicoModel medicos = await _medicoRepositorio.BuscarPorId(id);

            if (medicos is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medico)}: Busca do médico com ID: {id} foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Medico)}: Busca do médico com ID: {id} não foi realizada.");

            return medicos;
        }

        public async Task<List<MedicoModel>> BuscarTodosMedicos()
        {
            List<MedicoModel> medicos = await _medicoRepositorio.BuscarTodosMedicos();

            if (medicos is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medico)}: Busca de todos os médicos foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Medico)}: Busca de todos os médicos não foi realizada.");

            return medicos;
        }
    }
}
