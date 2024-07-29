namespace GerenciadorHospital.Models
{
    public class ConvenioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public float Preco { get; set; }

        public ConvenioModel() { }
    }
}
