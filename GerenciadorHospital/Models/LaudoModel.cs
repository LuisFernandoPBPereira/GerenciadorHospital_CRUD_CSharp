namespace GerenciadorHospital.Models
{
    public class LaudoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        //Pegamos o ID do paciente
        public int? PacienteId { get; set; }
        //Usamos um publilc virutal do tipo PacienteModel para recebermos o paciente
        public virtual PacienteModel? Paciente { get; set; }
    }
}
