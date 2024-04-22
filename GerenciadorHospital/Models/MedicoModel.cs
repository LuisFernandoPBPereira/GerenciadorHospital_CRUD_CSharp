using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorHospital.Models
{
    public class MedicoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        [NotMapped]
        public IFormFile? Doc { get; set; }
        public string? CaminhoDoc { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNasc { get; set; }
        public string Crm { get; set; }
        public string Especializacao { get; set; }
    }
}
