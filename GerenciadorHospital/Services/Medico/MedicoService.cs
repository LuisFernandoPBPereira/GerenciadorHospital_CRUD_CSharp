using GerenciadorHospital.Controllers;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Medico
{
    public class MedicoService : IMedicoService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMedicoRepositorio _medicoRepositorio;
        private readonly ILogger<MedicoController> _logger;
        BCryptPasswordHasher<MedicoModel> senhaComHash = new BCryptPasswordHasher<MedicoModel>();
        MensagensLog mensagensLog = new MensagensLog();

        #region Construtor
        public MedicoService(IAuthenticationService authenticationService,
                             IMedicoRepositorio medicoRepositorio,
                             ILogger<MedicoController> logger)
        {
            _authenticationService = authenticationService;
            _medicoRepositorio = medicoRepositorio;
            _logger = logger;
        }
        #endregion

        #region Service - Adicionar Médico
        public async Task<MedicoModel> Adicionar(MedicoDto medicoDto)
        {
            MedicoModel medicoModel = new MedicoModel(medicoDto);
            ValidaMedico validaMedico = new ValidaMedico(medicoModel);
            validaMedico.ValidacaoMedico();

            var medicoValidado = validaMedico.ValidaImagem();

            if (medicoValidado == false)
                throw new Exception("Não foi possível carregar a imagem");

            CadastroRequestDto novoMedico = new CadastroRequestDto(medicoModel);
            
            var medicoCadastrado = await _authenticationService.Register(novoMedico);
            
            var senhaMedico = senhaComHash.HashPassword(medicoModel, medicoModel.Senha);
            medicoModel.Senha = senhaMedico;

            MedicoModel medico = await _medicoRepositorio.Adicionar(medicoModel);

            if (medico is not null && medicoCadastrado is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medico)}: Cadastro do médico foi realizado.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_POST_Medico)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_POST_Medico)}");

            return medico ?? throw new Exception("Não foi possível cadastrar o médico, a response foi nula");
        }
        #endregion

        #region Service - Apagar Médico
        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _medicoRepositorio.Apagar(id);

            if (apagado)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medico)}: Remoção do médico foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_DEL_Medico)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_DEL_Medico)}");

            return apagado;
        }
        #endregion

        #region Service - Atualizar Médico
        public async Task<MedicoModel> Atualizar(MedicoDto medicoDto, int id)
        {
            MedicoModel medicoModel = new MedicoModel(medicoDto);
            ValidaMedico validaMedico = new ValidaMedico(medicoModel);
            validaMedico.ValidacaoMedico();

            var medicoValidado = validaMedico.ValidaImagem();

            if (medicoValidado == false)
                throw new Exception("Não foi possível carregar a imagem");

            MedicoModel medico = await _medicoRepositorio.Atualizar(medicoModel, id);

            if (medico is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medico)}: Atualização do médico foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_PUT_Medico)}:  {mensagensLog.ExibirMensagem(CodigosLogErro.E_PUT_Medico)}");

            return medico ?? throw new Exception("Não foi possível atualizar o médico, a response foi nula");
        }
        #endregion

        #region Service - Buscar Documento do Médico Por ID
        public async Task<FileContentResult> BuscarDocMedicoPorId(int id)
        {
            MedicoModel? medico = await _medicoRepositorio.BuscarDocMedicoPorId(id);

            string caminho = medico!.CaminhoDoc ?? string.Empty;

            ValidaMedico imagem = new ValidaMedico(medico);

            if (imagem is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medico)}: Busca do documento com ID: {id}, foi realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Medico)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Medico)} ->
                                        Busca do documento com ID: {id}, não foi realizada.");

            return imagem is null ? throw new Exception("Ocorreu um erro ao carregar a imagem") 
                                  : imagem.BuscarDocMedico(caminho);
        }
        #endregion

        #region Service - Buscar Medico Por ID
        public async Task<MedicoModel> BuscarPorId(int id)
        {
            MedicoModel? medicos = await _medicoRepositorio.BuscarPorId(id);

            if (medicos is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medico)}: Busca do médico com ID: {id} foi realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Medico)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Medico)} ->
                                        Busca do médico com ID: {id} não foi realizada.");

            return medicos ?? throw new Exception("Não foi possível buscar o médico por ID, a busca retornou nulo");
        }
        #endregion

        #region Service - Buscar Todos os Médicos
        public async Task<List<MedicoModel>> BuscarTodosMedicos()
        {
            List<MedicoModel> medicos = await _medicoRepositorio.BuscarTodosMedicos();

            if (medicos is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medico)}: Busca de todos os médicos foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_GET_Medico)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Medico)}");

            return medicos ?? throw new Exception("Não foi possível buscar todos médicos, a busca retornou nulo");
        }
        #endregion
    }
}
