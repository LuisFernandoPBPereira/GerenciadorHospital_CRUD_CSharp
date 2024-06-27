using GerenciadorHospital.Domain.Validations;

namespace GerenciadorHospital.Domain.Entites
{
    public class MedicamentoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Composicao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }

        public MedicamentoEntity() 
        { 
            Nome = string.Empty;
            Composicao = string.Empty;
        }

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

            domainValidation.VerificaId(Id);
            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Nome, nameof(Nome));
            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Composicao, nameof(Composicao));
            domainValidation.VerificaDataNaoPodeSerNoPassado(DataFabricacao, nameof(DataFabricacao));
            domainValidation.VerificaDataNaoPodeSerNoPassado(DataValidade, nameof(DataValidade));

            domainValidation.VerificaErros();
        }
    }
}
