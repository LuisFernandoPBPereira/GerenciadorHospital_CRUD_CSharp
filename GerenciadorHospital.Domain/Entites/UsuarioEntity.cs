using GerenciadorHospital.Domain.Validations;

namespace GerenciadorHospital.Domain.Entites
{
    public class UsuarioEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }

        public UsuarioEntity()
        {
            Nome = string.Empty;
            Senha = string.Empty;
            Role = string.Empty;
        }

        public UsuarioEntity(int id, string nome, string senha, string role)
        {
            Id = id;
            Nome = nome;
            Senha = senha;
            Role = role;

            Validate();
        }

        public void Validate()
        {
            DomainValidation domainValidation = new DomainValidation();

            domainValidation.VerificaId(Id);
            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Nome, nameof(Nome));
            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Role, nameof(Role));
            domainValidation.VerificaSenha(Senha);
            domainValidation.VerificaErros();
        }
    }
}
