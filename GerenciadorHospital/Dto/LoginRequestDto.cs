using System.ComponentModel.DataAnnotations;

namespace GerenciadorHospital.Dto
{
    public class LoginRequestDto
    {
        [Required]
        [MinLength(Consts.TamanhoMinimoUserName, ErrorMessage = Consts.ErroDeValidacaoTamanhoUserName)]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(Consts.RegexSenha, ErrorMessage = Consts.ErroDeValidacaoSenha)]
        public string? Senha { get; set; }
    }
}
