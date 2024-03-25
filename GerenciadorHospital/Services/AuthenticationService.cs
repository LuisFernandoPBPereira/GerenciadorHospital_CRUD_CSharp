using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
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

        public AuthenticationService(UserManager<UsuarioModel> usuarioRepositorio, IConfiguration configuration)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _configuration = configuration;
        }

        public async Task<string> Register(CadastroRequestDto request)
        {
            var userByUsername = await _usuarioRepositorio.FindByNameAsync(request.Nome);
            if (userByUsername is not null)
            {
                throw new ArgumentException($"User with username {request.Nome} already exists.");
            }

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

            var result = await _usuarioRepositorio.CreateAsync(user, request.Senha);

            await _usuarioRepositorio.AddToRoleAsync(user, Role.User);

            if (!result.Succeeded)
            {
                throw new ArgumentException($"Unable to register user {request.Nome} errors: {GetErrorsText(result.Errors)}");
            }

            return await Login( new LoginRequestDto { UserName = request.UserName, Senha = request.Senha });
        }

        public async Task<string> Login(LoginRequestDto request)
        {
            var user = await _usuarioRepositorio.FindByNameAsync(request.UserName);

            if (user is null || !await _usuarioRepositorio.CheckPasswordAsync(user, request.Senha))
            {
                throw new ArgumentException($"Unable to authenticate user {request.UserName}");
            }

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Role, user.Role),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var userRoles = await _usuarioRepositorio.GetRolesAsync(user);

            authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

            var token = GetToken(authClaims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

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

        private string GetErrorsText(IEnumerable<IdentityError> errors)
        {
            return string.Join(", ", errors.Select(error => error.Description).ToArray());
        }
    }
}
