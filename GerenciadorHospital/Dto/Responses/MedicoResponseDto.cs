using GerenciadorHospital.Models;

namespace GerenciadorHospital.Dto.Responses
{
    public class MedicoResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Crm { get; set; } = string.Empty;
        public string Especializacao { get; set; } = string.Empty;

        public MedicoResponseDto(MedicoModel medicoModel)
        {
            Id = medicoModel.Id;
            Nome = medicoModel.Nome;
            Crm = medicoModel.Crm;
            Especializacao = medicoModel.Especializacao;
        }
    }
}
