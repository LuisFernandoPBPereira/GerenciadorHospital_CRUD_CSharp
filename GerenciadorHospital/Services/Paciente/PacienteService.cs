using GerenciadorHospital.Controllers;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
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
        public PacienteService(IPacienteRepositorio pacienteRepositorio,
                               IAuthenticationService authenticationService,
                               ILogger<PacienteController> logger)
        {
            _pacienteRepositorio = pacienteRepositorio;
            _authenticationService = authenticationService;
            _logger = logger;
        }

        public async Task<PacienteModel> AdicionarPaciente(PacienteModel pacienteModel)
        {
            if (pacienteModel.TemConvenio == false && pacienteModel.DocConvenio.Length > 0)
            {
                throw new Exception("Não é possível adicionar uma carteira de convênio, caso o campo TemConvenio seja falso");
            }
            //É instanciado um novo objeto para a validação das imagens carregadas na requisição
            DocumentoImagemDto imagem = new DocumentoImagemDto();
            imagem.Doc = pacienteModel.Doc;
            imagem.DocConvenio = pacienteModel.DocConvenio;
            ValidaImagem validaImagem = new ValidaImagem(imagem, pacienteModel);
            var requestDtoValidado = validaImagem.ValidacaoImagem();

            if (!requestDtoValidado)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_Paciente)}: Não foi possível cadastrar um novo paciente.");
                throw new Exception("Não foi possível cadastrar um novo paciente");
            }

            PacienteModel paciente = await _pacienteRepositorio.Adicionar(pacienteModel);
            CadastroRequestDto novoPaciente = new CadastroRequestDto();

            novoPaciente.Nome = pacienteModel.Nome;
            novoPaciente.UserName = pacienteModel.Cpf;
            novoPaciente.Cpf = pacienteModel.Cpf;
            novoPaciente.Senha = pacienteModel.Senha;
            novoPaciente.DataNasc = pacienteModel.DataNasc;
            novoPaciente.Endereco = pacienteModel.Endereco;
            novoPaciente.Role = Role.Paciente;

            var pacienteCadastrado = await _authenticationService.Register(novoPaciente);

            if (paciente is not null && pacienteCadastrado is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Paciente)}: Cadastro do paciente foi realizado.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Paciente)}: Cadastro do paciente não foi realizado.");

            return paciente;
        }

        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _pacienteRepositorio.Apagar(id);

            if (apagado)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Paciente)}: Remoção do paciente foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Paciente)}: Remoção do paciente não foi realizada.");

            return apagado;
        }

        public async Task<PacienteModel> Atualizar(PacienteModel pacienteModel, int id)
        {
            pacienteModel.Id = id;
            PacienteModel paciente = await _pacienteRepositorio.Atualizar(pacienteModel, id);

            if (paciente is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Paciente)}: Atualização do paciente foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Paciente)}: Atualização do paciente não foi realizada.");

            return paciente;
        }

        public async Task<DocumentoImagemDto> AtualizarDoc(DocumentoImagemDto documentoImagemDto, int id)
        {
            PacienteModel paciente = await _pacienteRepositorio.BuscarPorId(id);
            ValidaImagem validaImagem = new ValidaImagem(documentoImagemDto, paciente);

            var requestDtoValidado = validaImagem.ValidacaoImagem();

            if (!requestDtoValidado)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_Paciente)}: Não foi possível atualizar a imagem");
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
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Paciente)}: Busca do documento do convênio com ID: {id}, não foi realizada.");

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
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Paciente)}: Busca do documento com ID: {id}, não foi realizada.");

            return imagem.BuscarImagem(caminho);
        }

        public async Task<PacienteModel> BuscarPorId(int id)
        {
            PacienteModel paciente = await _pacienteRepositorio.BuscarPorId(id);

            if (paciente is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Paciente)}: Busca do paciente com ID: {id}, foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Paciente)}: Busca do paciente com ID: {id}, não foi realizada.");

            return paciente;
        }

        public async Task<List<PacienteModel>> BuscarTodosPacientes()
        {
            List<PacienteModel> pacientes = await _pacienteRepositorio.BuscarTodosPacientes();

            if (pacientes is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Paciente)}: Busca de todos pacientes foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Paciente)}: Busca de todos pacientes não foi realizada.");

            return pacientes;
        }
    }
}
