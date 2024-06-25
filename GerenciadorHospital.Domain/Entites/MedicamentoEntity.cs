using GerenciadorHospital.Domain.Validations;

namespace GerenciadorHospital.Domain.Entites
{
    public class MedicamentoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Composicao { get; set; } = string.Empty;
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }

        public MedicamentoEntity() { }

        public MedicamentoEntity(
            int id,
            string nome,
            string composicao,
            DateTime dataFabricacao,
            DateTime dataValidade)
        {
            Id = id;
            Nome = nome;
            Composicao = composicao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;

            Validate();
        }

        private void Validate()
        {
            DomainValidation domainValidation = new DomainValidation();

            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Nome, nameof(Nome));
            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Composicao, nameof(Composicao));
        }
    }
}
