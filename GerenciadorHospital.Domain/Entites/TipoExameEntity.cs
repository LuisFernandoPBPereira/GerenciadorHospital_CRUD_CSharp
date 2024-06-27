using GerenciadorHospital.Domain.Validations;

namespace GerenciadorHospital.Domain.Entites
{
    public class TipoExameEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }

        public TipoExameEntity()
        {
            Nome = string.Empty;
        }

        public TipoExameEntity(int id, string nome, int? pacienteId, int? medicoId)
        {
            Id = id;
            Nome = nome;
            PacienteId = pacienteId;
            MedicoId = medicoId;

            Validate();
        }

        private void Validate()
        {
            DomainValidation domainValidation = new DomainValidation();

            domainValidation.VerificaId(Id);
            domainValidation.VerificaId(PacienteId);
            domainValidation.VerificaId(MedicoId);
            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Nome, nameof(Nome));
            domainValidation.VerificaErros();
        }
    }
}
