using GerenciadorHospital.Domain.Validations;

namespace GerenciadorHospital.Models
{
    public class PacienteEntity
    {
        // Doc: O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        #pragma warning disable CS8618
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataNasc { get; set; }
        public bool TemConvenio { get; set; }
        public string? ImgCarteiraDoConvenio { get; set; }
        public string? ImgDocumento { get; set; }
        //[NotMapped]
        //public IFormFile Doc { get; set; }
        //[NotMapped]
        //public IFormFile? DocConvenio { get; set; }
        public int? ConvenioId { get; set; }
        public virtual ConvenioEntity? Convenio {  get; set; }

        public PacienteEntity() {   }

        public PacienteEntity(int id,
            string nome,
            string cpf,
            string senha,
            string endereco,
            DateTime dataNasc,
            bool temConvenio,
            string? imgCarteiraDoConvenio,
            string? imgDocumento,
            int? convenioId,
            ConvenioEntity? convenio)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Senha = senha;
            Endereco = endereco;
            DataNasc = dataNasc;
            TemConvenio = temConvenio;
            ImgCarteiraDoConvenio = imgCarteiraDoConvenio;
            ImgDocumento = imgDocumento;
            ConvenioId = convenioId;
            Convenio = convenio;

            Validate();
        }

        private void Validate()
        {
            DomainValidation domainValidation = new DomainValidation();

            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Nome, nameof(Nome));
            domainValidation.VerificaCpf(Cpf);
            domainValidation.VerificaSenha(Senha);
            domainValidation.VerificaDataDeNascimento(DataNasc);

            domainValidation.VerificaErros();
        }
    }
}
