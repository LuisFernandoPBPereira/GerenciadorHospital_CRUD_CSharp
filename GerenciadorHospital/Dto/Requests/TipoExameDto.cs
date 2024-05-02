namespace GerenciadorHospital.Dto.Requests
{
    public class TipoExameDto
    {
        public string Nome { get; set; } = string.Empty;
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }
    }
}
