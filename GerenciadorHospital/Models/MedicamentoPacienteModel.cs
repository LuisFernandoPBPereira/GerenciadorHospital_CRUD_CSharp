namespace GerenciadorHospital.Models
{
    public class MedicamentoPacienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Composicao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
