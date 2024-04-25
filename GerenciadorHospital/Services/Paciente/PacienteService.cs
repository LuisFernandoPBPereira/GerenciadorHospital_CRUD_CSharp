using GerenciadorHospital.Controllers;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Utils;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace GerenciadorHospital.Services.Paciente
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<PacienteController> _logger;
        BCryptPasswordHasher<PacienteModel> senhaComHash = new BCryptPasswordHasher<PacienteModel>();
        MensagensLog mensagensLog = new MensagensLog();

        public PacienteService(IPacienteRepositorio pacienteRepositorio,
                               IAuthenticationService authenticationService,
                               ILogger<PacienteController> logger)
        {
            _pacienteRepositorio = pacienteRepositorio;
            _authenticationService = authenticationService;
            _logger = logger;
        }

        public async Task<PacienteModel> AdicionarPaciente(PacienteDto pacienteDto)
        {
            PacienteModel pacienteModel = new PacienteModel(pacienteDto);
            ValidaPaciente validaPaciente = new ValidaPaciente(pacienteModel);
            validaPaciente.ValidacaoPaciente();

            DocumentoImagemDto imagem = new DocumentoImagemDto(pacienteModel);
            ValidaImagem validaImagem = new ValidaImagem(imagem, pacienteModel);

            var requestDtoValidado = validaImagem.ValidacaoImagem();

            if (!requestDtoValidado)
            {
                _logger.LogWarning($"{nameof(Enums.CodigosLogErro.E_POST_Paciente)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_POST_Paciente)}");
                throw new Exception("Imagem inválida.");
            }

            CadastroRequestDto novoPaciente = new CadastroRequestDto(pacienteModel);

            var pacienteCadastrado = await _authenticationService.Register(novoPaciente);

            var senhaUsuario = senhaComHash.HashPassword(pacienteModel, pacienteModel.Senha);
            pacienteModel.Senha = senhaUsuario;

            PacienteModel paciente = await _pacienteRepositorio.Adicionar(pacienteModel);

            if (paciente is not null && pacienteCadastrado is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Paciente)}: Cadastro do paciente foi realizado.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_POST_Paciente)}:  {mensagensLog.ExibirMensagem(CodigosLogErro.E_POST_Paciente)}");

            return paciente;
        }

        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _pacienteRepositorio.Apagar(id);

            if (apagado)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Paciente)}: Remoção do paciente foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_DEL_Paciente)}:  {mensagensLog.ExibirMensagem(CodigosLogErro.E_DEL_Paciente)}");

            return apagado;
        }

        public async Task<PacienteModel> Atualizar(PacienteDto pacienteDto, int id)
        {
            PacienteModel pacienteModel = new PacienteModel(pacienteDto);
            ValidaPaciente validaPaciente = new ValidaPaciente(pacienteModel);
            validaPaciente.ValidacaoPaciente();

            DocumentoImagemDto documentoImagemDto = new DocumentoImagemDto(); 
            ValidaImagem validaImagem = new ValidaImagem(documentoImagemDto, pacienteModel);

            var pacienteValidado = validaImagem.ValidacaoImagem();

            if (pacienteValidado == false)
                throw new Exception("Não foi possível carregar a imagem");

            PacienteModel paciente = await _pacienteRepositorio.Atualizar(pacienteModel, id);

            if (paciente is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Paciente)}: Atualização do paciente foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_PUT_Paciente)}:  {mensagensLog.ExibirMensagem(CodigosLogErro.E_PUT_Paciente)}");

            return paciente;
        }

        public async Task<DocumentoImagemDto> AtualizarDoc(DocumentoImagemDto documentoImagemDto, int id)
        {
            PacienteModel paciente = await _pacienteRepositorio.BuscarPorId(id);
            ValidaImagem validaImagem = new ValidaImagem(documentoImagemDto, paciente);

            var requestDtoValidado = validaImagem.ValidacaoImagem();

            if (!requestDtoValidado)
            {
                _logger.LogError(@$"{nameof(Enums.CodigosLogErro.E_PUT_Paciente)}: 
                                  {mensagensLog.ExibirMensagem(CodigosLogErro.E_PUT_Paciente)}");
                throw new Exception("Não foi possível atualizar a imagem");
            }

            await _pacienteRepositorio.Atualizar(paciente, id);

            _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Paciente)}: Atualização da imagem foi realizada");

            return documentoImagemDto;

        }

        public async Task<FileContentResult> BuscarDocConvenioPorId(int id)
        {
            //Capturamos o paciente pelo ID
            PacienteModel paciente = await _pacienteRepositorio.BuscarDocConvenioPorId(id);

            if (paciente.TemConvenio == false)
                throw new Exception("Este paciente não possui convênio");

            string caminho = paciente.ImgCarteiraDoConvenio;

            var imagem = new BuscaImagem(paciente);

            if (imagem is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Paciente)}: Busca do documento do convênio com ID: {id}, foi realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Paciente)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Paciente)} ->
                                        Busca do documento do convênio com ID: {id}, não foi realizada.");

            return imagem.BuscarImagem(caminho);
        }

        public async Task<FileContentResult> BuscarDocPorId(int id)
        {
            PacienteModel paciente = await _pacienteRepositorio.BuscarDocPorId(id);

            string caminho = paciente.ImgDocumento;

            var imagem = new BuscaImagem(paciente);

            if (imagem is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Paciente)}: Busca do documento com ID: {id}, foi realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Paciente)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Paciente)} ->
                                        Busca do documento com ID: {id}, não foi realizada.");

            return imagem.BuscarImagem(caminho);
        }

        public async Task<PacienteModel> BuscarPorId(int id)
        {
            PacienteModel paciente = await _pacienteRepositorio.BuscarPorId(id);

            if (paciente is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Paciente)}: Busca do paciente com ID: {id}, foi realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Paciente)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Paciente)} ->
                                        Busca do paciente com ID: {id}, não foi realizada.");

            return paciente;
        }

        public async Task<List<PacienteModel>> BuscarTodosPacientes()
        {
            List<PacienteModel> pacientes = await _pacienteRepositorio.BuscarTodosPacientes();

            if (pacientes is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Paciente)}: Busca de todos pacientes foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_GET_Paciente)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Paciente)}");

            return pacientes;
        }
    }
}
