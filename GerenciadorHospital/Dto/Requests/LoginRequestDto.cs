using System.ComponentModel.DataAnnotations;

namespace GerenciadorHospital.Dto.Requests
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string? Senha { get; set; }
    }
}
