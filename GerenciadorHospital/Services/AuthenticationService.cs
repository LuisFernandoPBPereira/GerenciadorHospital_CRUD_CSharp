using FluentResults;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciadorHospital.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<UsuarioModel> _usuarioRepositorio;
        private readonly IConfiguration _configuration;
        BCryptPasswordHasher<UsuarioModel> senhaComHash = new BCryptPasswordHasher<UsuarioModel>();

        #region Construtor
        public AuthenticationService(UserManager<UsuarioModel> usuarioRepositorio, IConfiguration configuration)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _configuration = configuration;
        }
        #endregion

        #region Service - Cadastro do Usuário
        public async Task<Result<string>> Register(CadastroRequestDto request)
        {
            if (request.Senha.Length < 6) return Result.Fail(new Error("A senha deve no mínimo possuir 6 caracteres"));

            var usuarioPorUsername = await _usuarioRepositorio.FindByNameAsync(request.Nome);

            if (usuarioPorUsername is not null) return Result.Fail(new Error($"Usuário com o nome {request.Nome} já existe."));



            UsuarioModel user = new()
            {
                UserName = request.UserName,
                Nome = request.Nome,
                Cpf = request.Cpf,
                Senha = request.Senha,
                Endereco = request.Endereco,
                DataNasc = request.DataNasc,
                Role = request.Role,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var senhaUser = senhaComHash.HashPassword(user, request.Senha);
            user.Senha = senhaUser;

            var result = await _usuarioRepositorio.CreateAsync(user, user.Senha);

            if (!result.Succeeded) return Result.Fail(new Error($"não foi possível cadastrar o usuário {request.Nome}, erros: {GetErrorsText(result.Errors)}"));
            
            await _usuarioRepositorio.AddToRoleAsync(user, request.Role);


            return await Login( new LoginRequestDto { UserName = request.UserName, Senha = request.Senha });
        }
        #endregion

        #region Service - Login do Usuário
        public async Task<Result<string>> Login(LoginRequestDto request)
        {
            var user = await _usuarioRepositorio.FindByNameAsync(request.UserName);
            var isValidSenha = senhaComHash.VerifyHashedPassword(user, user.Senha, request.Senha);

            if(isValidSenha == PasswordVerificationResult.Success)
            {
                if (user is null || !await _usuarioRepositorio.CheckPasswordAsync(user, user.Senha))
                    return Result.Fail(new Error($"Não foi possível autenticar o usuário {request.UserName}"));

                var authClaims = new List<Claim>
                {
                    new(ClaimTypes.Name, user.UserName),
                    new(ClaimTypes.Role, user.Role),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var userRoles = await _usuarioRepositorio.GetRolesAsync(user);

                authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

                var token = GetToken(authClaims);

                return Result.Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

            return Result.Fail(new Error($"Não foi possível autenticar o usuário {request.UserName}"));

        }
        #endregion

        #region Service - Geração do Token JWT
        private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
        #endregion

        #region Service - Tratativa de Erro do Identity
        private string GetErrorsText(IEnumerable<IdentityError> errors)
        {
            return string.Join(", ", errors.Select(error => error.Description).ToArray());
        }
        #endregion
    }
}
