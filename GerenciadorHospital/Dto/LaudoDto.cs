using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorHospital.Dto
{
    public class LaudoDto
    {
        public string Descricao { get; set; } = string.Empty;
        public DateTime? DataCriacao { get; set; }
        [NotMapped]
        public IFormFile? ImagemLaudo { get; set; }
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public int? MedicamentoId { get; set; }
    }
}
