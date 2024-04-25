namespace GerenciadorHospital.Dto
{
    public class MedicamentoDto
    {
        public string Nome { get; set; }
        public string Composicao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
