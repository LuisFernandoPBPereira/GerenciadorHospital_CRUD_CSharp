using FluentResults;
using GerenciadorHospital.Dto;

namespace GerenciadorHospital.Services
{
    public interface IAuthenticationService
    {
        Task<Result<string>> Register(CadastroRequestDto request);
        Task<Result<string>> Login(LoginRequestDto request);
    }
}
