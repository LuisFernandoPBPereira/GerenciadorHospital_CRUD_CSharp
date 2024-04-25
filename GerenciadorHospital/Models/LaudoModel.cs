using GerenciadorHospital.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorHospital.Models
{
    public class LaudoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime? DataCriacao { get; set; }
        [NotMapped]
        public IFormFile? ImagemLaudo { get; set; }
        public string? CaminhoImagemLaudo { get; set; }
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public int? MedicamentoId { get; set; }
        public virtual PacienteModel? Paciente { get; set; }
        public virtual MedicoModel? Medico { get; set; }
        public virtual MedicamentoPacienteModel? Medicamento { get; set; }

        public LaudoModel() { }

        public LaudoModel(LaudoDto laudoDto)
        {
            Descricao = laudoDto.Descricao;
            DataCriacao = laudoDto.DataCriacao;
            ImagemLaudo = laudoDto.ImagemLaudo;
            PacienteId = laudoDto.PacienteId;
            MedicoId = laudoDto.MedicoId;
            MedicamentoId = laudoDto.MedicamentoId;
        }
    }
}
