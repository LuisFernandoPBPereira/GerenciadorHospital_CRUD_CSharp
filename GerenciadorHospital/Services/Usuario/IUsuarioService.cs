using GerenciadorHospital.Dto.Requests;

namespace GerenciadorHospital.Services.Usuario
{
    public interface IUsuarioService
    {
        public Task<FluentResults.Result<string>> Cadastrar( CadastroRequestDto usuarioModel);
        public Task<FluentResults.Result<string>> Login(LoginRequestDto usuarioModel);
    }
}
