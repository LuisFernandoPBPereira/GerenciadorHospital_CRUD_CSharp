namespace GerenciadorHospital.Models
{
    public class LaudoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int PacienteId { get; set; }
        public virtual PacienteModel Paciente { get; set; }
    }
}
