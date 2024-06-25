
using GerenciadorHospital.Domain.Exceptions;
using GerenciadorHospital.Domain.Validations;

namespace GerenciadorHospital.Models
{
    public class TipoExameEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }

        public TipoExameEntity() {    }

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

            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Nome, nameof(Nome));
            domainValidation.VerificaErros();
        }
    }
}
