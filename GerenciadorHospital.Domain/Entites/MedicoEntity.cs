using GerenciadorHospital.Domain.Validations;

namespace GerenciadorHospital.Domain.Entites
{
    public class MedicoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        //[NotMapped]
        //public IFormFile? Doc { get; set; }
        public string? CaminhoDoc { get; set; }
        public string Senha { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataNasc { get; set; }
        public string Crm { get; set; } = string.Empty;
        public string Especializacao { get; set; } = string.Empty;

        public MedicoEntity() { }

        public MedicoEntity(
            int id,
            string nome,
            string cpf,
            string? caminhoDoc,
            string senha,
            string endereco,
            DateTime dataNasc,
            string crm,
            string especializacao)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            CaminhoDoc = caminhoDoc;
            Senha = senha;
            Endereco = endereco;
            DataNasc = dataNasc;
            Crm = crm;
            Especializacao = especializacao;

            Validate();
        }

        private void Validate()
        {
            DomainValidation domainValidation = new DomainValidation();

            domainValidation.VerificaId(Id);
            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Nome, nameof(Nome));
            domainValidation.VerificaDataDeNascimento(DataNasc);
            domainValidation.VerificaSeStringNulaVazia(CaminhoDoc, nameof(CaminhoDoc));
            domainValidation.VerificaEndereco(Endereco);
            domainValidation.VerificaCrm(Crm);
            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Especializacao, nameof(Especializacao));
            domainValidation.VerificaCpf(Cpf);
            domainValidation.VerificaSenha(Senha);

            domainValidation.VerificaErros();
        }
    }
}
