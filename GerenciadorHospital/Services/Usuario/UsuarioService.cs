using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IAuthenticationService _authenticationService;
        public UsuarioService(IAuthenticationService authenticationService)
        {

            _authenticationService = authenticationService;

        }
        public async Task<FluentResults.Result<string>> Cadastrar(CadastroRequestDto usuarioModel)
        {
            if (usuarioModel.Role is Role.Medico or Role.Paciente)
                throw new ArgumentException("Não é possível criar um paciente ou um médico nesta página");

            var response = await _authenticationService.Register(usuarioModel);

            var resultadoDto = response.MostraResultadoDto();

            if (!resultadoDto.IsSuccess)
            {
                throw new Exception(resultadoDto.ToString());
            }

            return response;
        }

        public async Task<FluentResults.Result<string>> Login(LoginRequestDto usuarioModel)
        {
            var response = await _authenticationService.Login(usuarioModel);

            var resultadoDto = response.MostraResultadoDto();

            if (!resultadoDto.IsSuccess)
            {
                throw new Exception(resultadoDto.ToString());
            }

            return response;
        }
    }
}
