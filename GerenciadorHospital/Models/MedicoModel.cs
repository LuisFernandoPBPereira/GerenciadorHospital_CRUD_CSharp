namespace GerenciadorHospital.Models
{
    public class MedicoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNasc { get; set; }
        public string Crm { get; set; }
        public string Especializacao { get; set; }
    }
}
