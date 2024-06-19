using GerenciadorHospital.Domain.Validations;

namespace GerenciadorHospital.Models
{
    public class UsuarioEntity
    {
        #pragma warning disable CS0114 // O membro oculta o membro herdado; palavra-chave substituta ausente
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }

        public UsuarioEntity()
        {}

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
            DomainValidation.VerifyIsPositiveNumber(Id);
            DomainValidation.VerifyIsValidString(Nome);
            DomainValidation.VerifyIsStringWithoutNumbers(Nome);
            DomainValidation.VerifyIsValidString(Senha);
            DomainValidation.VerifyIsStringWithoutNumbers(Role);
            DomainValidation.VerifyIsValidString(Role);
        }
    }
}
