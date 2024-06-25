using GerenciadorHospital.Domain.Validations;

namespace GerenciadorHospital.Domain.Entites
{
    public class ConvenioEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal? Preco { get; set; }

        public ConvenioEntity() { }

        public ConvenioEntity(int id, string nome, decimal preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;

            Validate();
        }

        private void Validate()
        {
            DomainValidation domainValidation = new DomainValidation();

            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Nome, nameof(Nome));
            domainValidation.VerificaPreco(Preco);

            domainValidation.VerificaErros();
        }
    }
}
