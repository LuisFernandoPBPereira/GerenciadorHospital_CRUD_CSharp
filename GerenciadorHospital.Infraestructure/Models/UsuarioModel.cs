using Microsoft.AspNetCore.Identity;

namespace GerenciadorHospital.Models
{
    public class UsuarioModel : IdentityUser<int>
    {
        public string? Nome { get; set; }
        public string? Senha { get; set; }
        public string? Role { get; set; }
    }
}
