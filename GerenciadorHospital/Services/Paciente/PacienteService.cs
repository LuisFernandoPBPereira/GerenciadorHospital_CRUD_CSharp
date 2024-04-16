using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Paciente
{
    public class PacienteService
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
    }
}
