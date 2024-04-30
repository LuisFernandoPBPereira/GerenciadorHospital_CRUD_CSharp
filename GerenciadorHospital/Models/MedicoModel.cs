using GerenciadorHospital.Dto.Requests;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorHospital.Models
{
    public class MedicoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile? Doc { get; set; }
        public string? CaminhoDoc { get; set; }
        public string Senha { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataNasc { get; set; }
        public string Crm { get; set; } = string.Empty;
        public string Especializacao { get; set; } = string.Empty;

        public MedicoModel() {   }

        public MedicoModel(MedicoDto medicoDto)
        {
            Nome = medicoDto.Nome;
            Cpf = medicoDto.Cpf;
            Doc = medicoDto.Doc;
            Senha = medicoDto.Senha;
            Endereco = medicoDto.Endereco;
            DataNasc = medicoDto.DataNasc;
            Crm = medicoDto.Crm;
            Especializacao = medicoDto.Especializacao;
        }
    }
}
