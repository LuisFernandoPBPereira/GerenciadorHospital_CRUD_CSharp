using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Paciente
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;
        private readonly IAuthenticationService _authenticationService;
        public PacienteService(IPacienteRepositorio pacienteRepositorio,
                               IAuthenticationService authenticationService)
        {
            _pacienteRepositorio = pacienteRepositorio;
            _authenticationService = authenticationService;
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

            if (requestDtoValidado)
            {
                PacienteModel paciente = await _pacienteRepositorio.Adicionar(pacienteModel);
                CadastroRequestDto novoPaciente = new CadastroRequestDto();

                novoPaciente.Nome = pacienteModel.Nome;
                novoPaciente.UserName = pacienteModel.Cpf;
                novoPaciente.Cpf = pacienteModel.Cpf;
                novoPaciente.Senha = pacienteModel.Senha;
                novoPaciente.DataNasc = pacienteModel.DataNasc;
                novoPaciente.Endereco = pacienteModel.Endereco;
                novoPaciente.Role = Role.Paciente;

                await _authenticationService.Register(novoPaciente);

                return paciente;
            }
            else
            {
                throw new Exception("Não foi possível cadastrar um novo paciente");
            }
        }

        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _pacienteRepositorio.Apagar(id);
            return apagado;
        }

        public async Task<PacienteModel> Atualizar(PacienteModel pacienteModel, int id)
        {
            pacienteModel.Id = id;
            PacienteModel paciente = await _pacienteRepositorio.Atualizar(pacienteModel, id);
            return paciente;
        }

        public async Task<DocumentoImagemDto> AtualizarDoc(DocumentoImagemDto documentoImagemDto, int id)
        {
            PacienteModel paciente = await _pacienteRepositorio.BuscarPorId(id);
            ValidaImagem validaImagem = new ValidaImagem(documentoImagemDto, paciente);

            var requestDtoValidado = validaImagem.ValidacaoImagem();

            if (requestDtoValidado)
            {
                await _pacienteRepositorio.Atualizar(paciente, id);
                return documentoImagemDto;
            }

            throw new("Não foi possível atualizar a imagem");
        }

        public async Task<FileContentResult> BuscarDocConvenioPorId(int id)
        {
            //Capturamos o paciente pelo ID
            PacienteModel paciente = await _pacienteRepositorio.BuscarDocConvenioPorId(id);

            if (paciente.TemConvenio == false)
                throw new Exception("Este paciente não possui convênio");

            string caminho = paciente.ImgCarteiraDoConvenio;

            var imagem = new BuscaImagem(paciente);

            return imagem.BuscarImagem(caminho);
        }

        public async Task<FileContentResult> BuscarDocPorId(int id)
        {
            PacienteModel paciente = await _pacienteRepositorio.BuscarDocPorId(id);

            string caminho = paciente.ImgDocumento;

            var imagem = new BuscaImagem(paciente);

            return imagem.BuscarImagem(caminho);
        }

        public async Task<PacienteModel> BuscarPorId(int id)
        {
            PacienteModel paciente = await _pacienteRepositorio.BuscarPorId(id);
            return paciente;
        }

        public async Task<List<PacienteModel>> BuscarTodosPacientes()
        {
            List<PacienteModel> pacientes = await _pacienteRepositorio.BuscarTodosPacientes();
            return pacientes;
        }
    }
}
