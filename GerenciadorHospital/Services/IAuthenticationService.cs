using FluentResults;
using GerenciadorHospital.Dto.Requests;

namespace GerenciadorHospital.Services
{
    public interface IAuthenticationService
    {
        Task<Result<string>> Register(CadastroRequestDto request);
        Task<Result<string>> Login(LoginRequestDto request);
    }
}
