using GerenciadorHospital.Controllers;
using GerenciadorHospital.Dto.Extensions;
using GerenciadorHospital.Dto.Requests;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Enums;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<UsuarioController> _logger;
        MensagensLog mensagensLog = new MensagensLog();
        public UsuarioService(IAuthenticationService authenticationService,
                              ILogger<UsuarioController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }
        public async Task<FluentResults.Result<string>> Cadastrar(CadastroRequestDto usuarioModel)
        {
            if (usuarioModel.Role is Role.Medico or Role.Paciente)
                throw new ArgumentException("Não é possível criar um paciente ou um médico nesta página");

            var response = await _authenticationService.Register(usuarioModel);

            var resultadoDto = response.MostraResultadoDto();

            if (!resultadoDto.IsSuccess)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_POST_Usuario)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_POST_Usuario)}, {resultadoDto}");
                throw new Exception(resultadoDto.ToString());
            }

            _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Usuario)}: Cadastro do usuário foi realizado.");

            return response;
        }

        public async Task<FluentResults.Result<string>> Login(LoginRequestDto usuarioModel)
        {
            var response = await _authenticationService.Login(usuarioModel);

            var resultadoDto = response.MostraResultadoDto();

            if (!resultadoDto.IsSuccess)
            {
                _logger.LogError($"{nameof(Enums.CodigosLogErro.E_POST_Usuario)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_POST_Usuario)}, {resultadoDto.Erros!.FirstOrDefault()}");
                throw new Exception(resultadoDto.Erros!.FirstOrDefault());
            }

            _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Usuario)}: Login do usuário foi realizado");

            return response;
        }
    }
}
