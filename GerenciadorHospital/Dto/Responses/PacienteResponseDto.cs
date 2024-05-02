using GerenciadorHospital.Models;

namespace GerenciadorHospital.Dto.Responses
{
    public class PacienteResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNasc { get; set; }
        public bool TemConvenio { get; set; }

        public PacienteResponseDto(PacienteModel paciente)
        {
            Id = paciente.Id;
            Nome = paciente.Nome;
            DataNasc = paciente.DataNasc;
            TemConvenio = paciente.TemConvenio;
        }
    }
}
