using GerenciadorHospital.Dto;

namespace GerenciadorHospital.Models
{
    public class MedicamentoPacienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Composicao { get; set; } = string.Empty;
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }

        public MedicamentoPacienteModel(){  }

        public MedicamentoPacienteModel(MedicamentoDto medicamentoDto)
        {
            Nome = medicamentoDto.Nome;
            Composicao = medicamentoDto.Composicao;
            DataFabricacao = medicamentoDto.DataFabricacao;
            DataValidade = medicamentoDto.DataValidade;
        }
    }
}
