using System.ComponentModel.DataAnnotations;

namespace GerenciadorHospital.Dto
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string? Senha { get; set; }
    }
}
