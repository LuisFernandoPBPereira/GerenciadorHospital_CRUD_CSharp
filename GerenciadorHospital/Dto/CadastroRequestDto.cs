using System.ComponentModel.DataAnnotations;

namespace GerenciadorHospital.Dto
{
    public class CadastroRequestDto
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public DateTime DataNasc { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
