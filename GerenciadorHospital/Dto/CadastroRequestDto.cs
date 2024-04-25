using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorHospital.Dto
{
    public class CadastroRequestDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(Consts.TamanhoMinimoUserName, ErrorMessage = Consts.ErroDeValidacaoTamanhoUserName)]
        public string UserName { get; set; }
        [Required]
        [MinLength(Consts.TamanhoMinimoUserName, ErrorMessage = Consts.ErroDeValidacaoTamanhoUserName)]
        public string Nome { get; set; }
        [Required]
        [MinLength(Consts.TamanhoCPF, ErrorMessage = Consts.ErroDeValidacaoCPF)]
        public string Cpf { get; set; }
        [Required]
        [RegularExpression(Consts.RegexSenha, ErrorMessage = Consts.ErroDeValidacaoSenha)]
        public string Senha { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public DateTime DataNasc { get; set; }
        [Required]
        public string Role { get; set; }

        public CadastroRequestDto()
        {
            
        }

        public CadastroRequestDto(PacienteModel pacienteModel)
        {
            Nome = pacienteModel.Nome;
            UserName = pacienteModel.Cpf;
            Cpf = pacienteModel.Cpf;
            Senha = pacienteModel.Senha;
            DataNasc = pacienteModel.DataNasc;
            Endereco = pacienteModel.Endereco;
            Role = Entities.Role.Paciente;
        }
    }
}
