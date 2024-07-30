using GerenciadorHospital.Domain.Validations;

namespace GerenciadorHospital.Domain.Entites
{
    public class MedicoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNasc { get; set; }
        public string Crm { get; set; }
        public string Especializacao { get; set; }

        public MedicoEntity() 
        {
            Nome = string.Empty;
            Cpf = string.Empty;
            Senha = string.Empty;
            Endereco = string.Empty;
            Crm = string.Empty;
            Especializacao = string.Empty;
        }

        public MedicoEntity(
            string nome,
            string cpf,
            string senha,
            string endereco,
            DateTime dataNasc,
            string crm,
            string especializacao)
        {
            Nome = nome;
            Cpf = cpf;
            Senha = senha;
            Endereco = endereco;
            DataNasc = dataNasc;
            Crm = crm;
            Especializacao = especializacao;

            Validate();
        }
        
        public MedicoEntity(
            int id,
            string nome,
            string cpf,
            string senha,
            string endereco,
            DateTime dataNasc,
            string crm,
            string especializacao)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
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

            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Nome, nameof(Nome));
            domainValidation.VerificaDataDeNascimento(DataNasc);
            domainValidation.VerificaEndereco(Endereco);
            domainValidation.VerificaCrm(Crm);
            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Especializacao, nameof(Especializacao));
            domainValidation.VerificaCpf(Cpf);
            domainValidation.VerificaSenha(Senha);

            domainValidation.VerificaErros();
        }
    }
}
