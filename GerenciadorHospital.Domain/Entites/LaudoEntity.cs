using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorHospital.Models
{
    public class LaudoEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime? DataCriacao { get; set; }
        //[NotMapped]
        //public IFormFile? ImagemLaudo { get; set; }
        public string? CaminhoImagemLaudo { get; set; }
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public int? MedicamentoId { get; set; }
        public int? RegistroConsultaModelId { get; set; }
        public virtual PacienteEntity? Paciente { get; set; }
        public virtual MedicoEntity? Medico { get; set; }
        public virtual MedicamentoEntity? Medicamento { get; set; }

        public LaudoEntity() { }

    }
}
