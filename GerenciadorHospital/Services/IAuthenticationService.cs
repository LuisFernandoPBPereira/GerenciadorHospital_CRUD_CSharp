using GerenciadorHospital.Dto;

namespace GerenciadorHospital.Services
{
    public interface IAuthenticationService
    {
        Task<string> Register(CadastroRequestDto request);
        Task<string> Login(LoginRequestDto request);
    }
}
